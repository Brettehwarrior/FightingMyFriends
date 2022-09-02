using Fighter.Data;
using Fighter.StateMachine.States.SuperStates;

namespace Fighter.StateMachine.States.SubStates
{
    public class FighterFallState : FighterAirState
    {
        public FighterFallState(Common.Fighter fighter, FighterStateMachine stateMachine, FighterData fighterData, string animationName) : base(fighter, stateMachine, fighterData, animationName)
        {
        }


        public override void CheckTransitions()
        {
            base.CheckTransitions();
            
            // Check if on the ground
            if (fighter.IsGrounded)
            {
                stateMachine.ChangeState(State.Land);
            }
        }
    }
}