using Fighter.Data;
using UnityEngine;

namespace Fighter.Common.StateMachine
{
    public abstract class FighterState
    {
        protected readonly Fighter fighter;
        protected readonly FighterStateMachine stateMachine;
        protected readonly FighterData fighterData;

        protected Vector2 MovementInput;

        protected float startTime;
        
        private string _animationName;
        
        protected FighterState(Common.Fighter fighter, FighterStateMachine stateMachine, FighterData fighterData, string animationName)
        {
            this.fighter = fighter;
            this.stateMachine = stateMachine;
            this.fighterData = fighterData;
            _animationName = animationName;
        }

        public virtual void Enter()
        {
            startTime = Time.time;
            fighter.Anim.Play(_animationName);
            
            Debug.Log("Entering " + _animationName);
        }

        public virtual void Update()
        {
            MovementInput = fighter.InputHandler.MovementInput;
        }
        
        public virtual void FixedUpdate()
        {
            
        }

        public virtual void LateUpdate()
        {
            
        }

        public virtual void Exit()
        {
            
        }

        public virtual void CheckTransitions()
        {
            
        }
    }
}