using System;
using Fighter.Common.StateMachine;
using Fighter.Data;
using UnityEngine;

namespace Fighter.Common
{
    public class Fighter : MonoBehaviour
    {
        // Components
        public FighterStateMachine StateMachine { get; private set; }
        public FighterInputHandler InputHandler { get; private set; }
        
        // Values
        public int FacingDirection { get; private set; }
        public Vector2 Velocity { get; private set; }
        public bool IsGrounded { get; private set; }
        
        // Private members
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
            StateMachine = new FighterStateMachine();
        }

        private void Start()
        {
            _movement.SetGravityScale(fighterData.gravityScale);
            StateMachine.Initialize(State.Idle, this, fighterData);
            FacingDirection = 1;

            InputHandler.AttackEvent.AddListener(Attack);
        }

        private void Update()
        {
            StateMachine.CurrentState.Update();
        }
        
        private void FixedUpdate()
        {
            Velocity = _movement.CurrentVelocity;
            IsGrounded = _movement.IsGrounded;
            StateMachine.CurrentState.FixedUpdate();
        }

        private void LateUpdate()
        {
            StateMachine.CurrentState.LateUpdate();
            StateMachine.CurrentState.CheckTransitions();
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
    }
}