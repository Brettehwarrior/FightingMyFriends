using DefaultNamespace;
using Fighter.Data;
using UnityEngine;

namespace Fighter.StateMachine.States.SubStates
{
    public class FighterIdleState : FighterGroundedState
    {
        public FighterIdleState(Fighter fighter, FighterStateMachine stateMachine, FighterData fighterData, string animationName) : base(fighter, stateMachine, fighterData, animationName)
        {
        }
        
        public override void Enter()
        {
            base.Enter();
            
            fighter.SetHorizontalVelocity(0f);
        }

        public override void UpdateLogic()
        {
            base.UpdateLogic();

            if (Movement.x != 0f)
            {
                stateMachine.ChangeState(fighter.States.WalkState);
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