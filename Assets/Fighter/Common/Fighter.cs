using System;
using Fighter.Common.Collisions;
using Fighter.Common.StateMachine;
using Fighter.Data;
using UnityEngine;

namespace Fighter.Common
{
    public class Fighter : MonoBehaviour, IHittable
    {
        // Components
        public FighterInputHandler InputHandler { get; private set; }
        
        // Values
        public int FacingDirection { get; private set; }
        public Vector2 Velocity { get; private set; }
        public bool IsGrounded { get; private set; }
        
        // Private members
        private FighterStateMachine _stateMachine;
        private FighterMovement _movement;

        // Serialized Fields
        [SerializeField] private FighterData fighterData;
        [SerializeField] private Animator animator;
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private Transform hurtboxParent;

        public Animator Anim => animator;
        
        private void Awake()
        {
            InputHandler = GetComponent<FighterInputHandler>();
            _movement = GetComponent<FighterMovement>();
            _stateMachine = new FighterStateMachine();
        }

        private void Start()
        {
            _movement.SetGravityScale(fighterData.gravityScale);
            _stateMachine.Initialize(State.Idle, this, fighterData);
            FacingDirection = 1;
        }

        private void Update()
        {
            _stateMachine.CurrentState.Update();
        }
        
        private void FixedUpdate()
        {
            Velocity = _movement.CurrentVelocity;
            IsGrounded = _movement.IsGrounded;
            _stateMachine.CurrentState.FixedUpdate();
        }

        private void LateUpdate()
        {
            _stateMachine.CurrentState.LateUpdate();
            _stateMachine.CurrentState.CheckTransitions();
        }

        public void SetHorizontalVelocity(float velocity)
        {
            _movement.SetHorizontalVelocity(velocity);
        }
        
        public void SetVerticalVelocity(float velocity)
        {
            _movement.SetVerticalVelocity(velocity);
        }

        public void TryFlip(float x)
        {
            if (x != 0 && Math.Sign(x) != FacingDirection)
            {
                Flip();
            }
        }

        private void Flip()
        {
            FacingDirection = -FacingDirection;
            spriteRenderer.flipX = FacingDirection == -1;
            hurtboxParent.Rotate(0, 180, 0);
        }
        
        public void Jump(float velocity)
        {
            _movement.Jump(velocity);
        }

        private void Attack()
        {
            Debug.Log("Attacking");
        }

        public void Hit(HurtboxData hurtboxData, bool shouldFlip)
        {
            Debug.Log("Hit");
            _stateMachine.ChangeState(State.Knockback);
            
            // Set velocity according to hurtbox angle and knockback
            SetHorizontalVelocity(hurtboxData.knockback * Mathf.Sin(hurtboxData.angle * Mathf.Deg2Rad * (shouldFlip?-1:1)));
            SetVerticalVelocity(hurtboxData.knockback * Mathf.Cos(hurtboxData.angle * Mathf.Deg2Rad));
        }
    }
}