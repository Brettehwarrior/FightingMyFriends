using DefaultNamespace;
using Fighter.Data;

namespace Fighter.StateMachine.States.SubStates
{
    public class FighterWalkState : FighterGroundedState
    {
        public FighterWalkState(Fighter fighter, FighterStateMachine stateMachine, FighterData fighterData, string animationName) : base(fighter, stateMachine, fighterData, animationName)
        {
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void UpdateLogic()
        {
            base.UpdateLogic();

            fighter.TryFlip(Movement.x);
            fighter.SetHorizontalVelocity(fighterData.walkVelocity * Movement.x);
            
            // Transition out
            if (Movement.x == 0f)
            {
                stateMachine.ChangeState(fighter.States.IdleState);
            }
        }

        public override void UpdatePhysics()
        {
            base.UpdatePhysics();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void DoChecks()
        {
            base.DoChecks();
        }
    }
}