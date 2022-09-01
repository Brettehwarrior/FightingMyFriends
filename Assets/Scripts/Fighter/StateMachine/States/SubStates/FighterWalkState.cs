using Fighter.Data;
using Fighter.StateMachine.States.SuperStates;

namespace Fighter.StateMachine.States.SubStates
{
    public class FighterWalkState : FighterGroundedState
    {
        public FighterWalkState(Fighter fighter, FighterStateMachine stateMachine, FighterData fighterData, string animationName) : base(fighter, stateMachine, fighterData, animationName)
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