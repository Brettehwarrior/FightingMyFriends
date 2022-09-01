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
            fighter.Anim.Play(_animationName);
            
            Debug.Log("Entering state" + _animationName);
        }

        public virtual void Update()
        {
            
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