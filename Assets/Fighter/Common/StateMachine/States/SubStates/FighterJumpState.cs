using Fighter.Common.StateMachine.States.SuperStates;
using Fighter.Data;

namespace Fighter.Common.StateMachine.States.SubStates
{
    public class FighterJumpState : FighterAirState
    {
        public FighterJumpState(Fighter fighter, FighterStateMachine stateMachine, FighterData fighterData, string animationName) : base(fighter, stateMachine, fighterData, animationName)
        {
        }
        
        public override void Enter()
        {
            base.Enter();
            fighter.Jump(fighterData.jumpSpeed);
        }

        public override void CheckTransitions()
        {
            base.CheckTransitions();
            if (fighter.Velocity.y <= 0)
            {
                // Transition to falling state
                stateMachine.ChangeState(State.Fall);
            }
        }
    }
}