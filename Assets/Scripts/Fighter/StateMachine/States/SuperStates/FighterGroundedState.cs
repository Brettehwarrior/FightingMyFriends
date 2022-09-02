using Fighter.Data;
using UnityEngine;

namespace Fighter.StateMachine.States.SuperStates
{
    public class FighterGroundedState : FighterState
    {
        public FighterGroundedState(Fighter fighter, FighterStateMachine stateMachine, FighterData fighterData, string animationName) : base(fighter, stateMachine, fighterData, animationName)
        {
        }

        public override void CheckTransitions()
        {
            base.CheckTransitions();
            
            // Jump transition
            if (fighter.InputHandler.JumpInput)
            {
                stateMachine.ChangeState(State.Jump);
            }
            // Fall transition
            else if (!fighter.IsGrounded)
            {
                stateMachine.ChangeState(State.Fall);
            }
        }
    }
}