using System;
using Fighter.Data;
using UnityEngine;

namespace Fighter.StateMachine
{
    public class Fighter : MonoBehaviour
    {
        public FighterStateMachine StateMachine { get; private set; }
        public PlayerInputHandler InputHandler { get; private set; }
        public FighterStateFactory States { get; private set; }
        
        public int FacingDirection { get; private set; }
        
        private FighterMovement _movement;

        [SerializeField] private FighterData data;
        [SerializeField] private Animator animator;
        [SerializeField] private SpriteRenderer spriteRenderer;

        public Animator Anim => animator;
        
        private void Awake()
        {
            InputHandler = GetComponent<PlayerInputHandler>();
            _movement = GetComponent<FighterMovement>();
            StateMachine = new FighterStateMachine();
            States = new FighterStateFactory(this, StateMachine, data);
        }

        private void Start()
        {
            StateMachine.Initialize(States.IdleState);
            FacingDirection = 1;
        }

        private void Update()
        {
            StateMachine.CurrentState.UpdateLogic();
        }
        
        private void FixedUpdate()
        {
            StateMachine.CurrentState.UpdatePhysics();
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

        public void Flip()
        {
            FacingDirection = -FacingDirection;
            spriteRenderer.flipX = FacingDirection == -1;
        }
    }
}