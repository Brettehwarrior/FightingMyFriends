using DefaultNamespace;
using Fighter.Data;
using UnityEngine;

namespace Fighter.StateMachine.States.SubStates
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

        public override void UpdatePhysics()
        {
            base.UpdatePhysics();

            if (fighter.Velocity.y <= 0)
            {
                // Transition to falling state
                stateMachine.ChangeState(fighter.States.FallState);
            }
        }
    }
}