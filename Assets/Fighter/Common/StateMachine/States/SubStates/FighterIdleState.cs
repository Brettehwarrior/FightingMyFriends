using Fighter.Common.StateMachine.States.SuperStates;
using Fighter.Data;

namespace Fighter.Common.StateMachine.States.SubStates
{
    public class FighterIdleState : FighterGroundedState
    {
        public FighterIdleState(Common.Fighter fighter, FighterStateMachine stateMachine, FighterData fighterData, string animationName) : base(fighter, stateMachine, fighterData, animationName)
        {
        }
        
        public override void Enter()
        {
            base.Enter();
            
            fighter.SetHorizontalVelocity(0f);
        }
        
        public override void CheckTransitions()
        {
            base.CheckTransitions();

            if (MovementInput.x != 0f)
            {
                stateMachine.ChangeState(State.Walk);
            }
        }
    }
}