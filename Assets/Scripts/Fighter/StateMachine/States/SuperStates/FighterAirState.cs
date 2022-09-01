using Fighter.Data;

namespace Fighter.StateMachine.States.SuperStates
{
    public class FighterAirState : FighterState
    {
        public FighterAirState(global::Fighter.StateMachine.Fighter fighter, FighterStateMachine stateMachine, FighterData fighterData, string animationName) : base(fighter, stateMachine, fighterData, animationName)
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