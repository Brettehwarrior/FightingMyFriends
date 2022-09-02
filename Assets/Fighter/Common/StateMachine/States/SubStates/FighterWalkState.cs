using Fighter.Common.StateMachine.States.SuperStates;
using Fighter.Data;

namespace Fighter.Common.StateMachine.States.SubStates
{
    public class FighterWalkState : FighterGroundedState
    {
        public FighterWalkState(Common.Fighter fighter, FighterStateMachine stateMachine, FighterData fighterData, string animationName) : base(fighter, stateMachine, fighterData, animationName)
        {
        }
        
        public override void Update()
        {
            base.Update();

            fighter.TryFlip(MovementInput.x);
            fighter.SetHorizontalVelocity(fighterData.walkVelocity * MovementInput.x);
            
        }
        
        public override void CheckTransitions()
        {
            base.CheckTransitions();
            
            if (MovementInput.x == 0f)
            {
                stateMachine.ChangeState(State.Idle);
            }
        }
    }
}