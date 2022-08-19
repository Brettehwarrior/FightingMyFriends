using Fighter.Data;
using Fighter.StateMachine;
using UnityEngine;

namespace DefaultNamespace
{
    public class FighterGroundedState : FighterState
    {
        protected Vector2 Movement;
        
        public FighterGroundedState(Fighter.StateMachine.Fighter fighter, FighterStateMachine stateMachine, FighterData fighterData, string animationName) : base(fighter, stateMachine, fighterData, animationName)
        {
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void UpdateLogic()
        {
            base.UpdateLogic();
            Movement = fighter.InputHandler.MovementInput;
            
            // Jump transition
            if (fighter.InputHandler.JumpInput)
            {
                stateMachine.ChangeState(fighter.States.JumpState);
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