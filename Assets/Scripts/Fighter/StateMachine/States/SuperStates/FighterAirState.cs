using Fighter.Data;
using Fighter.StateMachine;

namespace DefaultNamespace
{
    public class FighterAirState : FighterState
    {
        public FighterAirState(Fighter.StateMachine.Fighter fighter, FighterStateMachine stateMachine, FighterData fighterData, string animationName) : base(fighter, stateMachine, fighterData, animationName)
        {
        }

        public override void Enter()
        {
            base.Enter();
        }
        
        public override void UpdatePhysics()
        {
            base.UpdatePhysics();
            
            // Check if on the ground
            if (fighter.IsGrounded)
            {
                stateMachine.ChangeState(fighter.States.LandingState);
            }
        }
    }
}