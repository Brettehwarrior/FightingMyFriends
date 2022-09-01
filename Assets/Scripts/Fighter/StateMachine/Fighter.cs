using System;
using Fighter.Data;
using UnityEngine;
using UnityEngine.Serialization;

namespace Fighter.StateMachine
{
    public class Fighter : MonoBehaviour
    {
        // Components
        public FighterStateMachine StateMachine { get; private set; }
        public PlayerInputHandler InputHandler { get; private set; }
        
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

        public Animator Anim => animator;
        
        private void Awake()
        {
            InputHandler = GetComponent<PlayerInputHandler>();
            _movement = GetComponent<FighterMovement>();
            _movement.SetGravityScale(fighterData.gravityScale);
            StateMachine = new FighterStateMachine();
        }

        private void Start()
        {
            StateMachine.Initialize(State.Idle, this, fighterData);
            FacingDirection = 1;
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
        }
        
        public void Jump(float velocity)
        {
            _movement.Jump(velocity);
        }
    }
}