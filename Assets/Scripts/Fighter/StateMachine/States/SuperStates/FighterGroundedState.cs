using Fighter.Data;
using UnityEngine;

namespace Fighter.StateMachine.States.SuperStates
{
    public class FighterGroundedState : FighterState
    {
        protected Vector2 MovementInput;
        
        public FighterGroundedState(global::Fighter.StateMachine.Fighter fighter, FighterStateMachine stateMachine, FighterData fighterData, string animationName) : base(fighter, stateMachine, fighterData, animationName)
        {
        }
        
        public override void Update()
        {
            base.Update();
            MovementInput = fighter.InputHandler.MovementInput;
        }
        
        public override void CheckTransitions()
        {
            base.CheckTransitions();
            
            // Jump transition
            if (fighter.InputHandler.JumpInput)
            {
                stateMachine.ChangeState(State.Jump);
            }
        }
    }
}