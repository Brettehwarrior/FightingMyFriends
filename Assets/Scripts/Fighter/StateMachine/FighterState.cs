using Fighter.Data;
using UnityEngine;

namespace Fighter.StateMachine
{
    public abstract class FighterState
    {
        protected Fighter fighter;
        protected FighterStateMachine stateMachine;
        protected FighterData fighterData;

        protected float startTime;
        
        private string _animationName;
        
        protected FighterState(Fighter fighter, FighterStateMachine stateMachine, FighterData fighterData, string animationName)
        {
            this.fighter = fighter;
            this.stateMachine = stateMachine;
            this.fighterData = fighterData;
            _animationName = animationName;
        }

        public virtual void Enter()
        {
            startTime = Time.time;
            DoChecks();
            fighter.Anim.Play(_animationName);
        }

        public virtual void UpdateLogic()
        {
            
        }

        public virtual void UpdatePhysics()
        {
            DoChecks();
        }

        public virtual void Exit()
        {
            
        }

        public virtual void DoChecks()
        {
            
        }
        
        protected void SwitchState(FighterState newState)
        {
            // Exit();
            // newState.Enter();
            // stateMachine.CurrentState = newState;
        }
    }
}