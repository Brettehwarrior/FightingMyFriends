using System;
using Fighter.Data;

namespace Fighter.Common.StateMachine.States.SuperStates
{
    public class FighterAirState : FighterState
    {
        public FighterAirState(Fighter fighter, FighterStateMachine stateMachine, FighterData fighterData, string animationName) : base(fighter, stateMachine, fighterData, animationName)
        {
        }
        
        public override void Update()
        {
            base.Update();
            
            // Air movement
            
            // Air horizontal drift
            if (MovementInput.x != 0 && (Math.Sign(MovementInput.x) != Math.Sign(fighter.Velocity.x) ||
                                         Math.Abs(fighter.Velocity.x) < fighterData.maxAirSpeed))
            {
                fighter.SetHorizontalVelocity(fighter.Velocity.x + MovementInput.x * fighterData.airAcceleration);
            }
            else if (MovementInput.x == 0)
            {
                fighter.SetHorizontalVelocity(fighter.Velocity.x * fighterData.airFriction);
            }
            
            // Terminal velocity
            if (fighter.Velocity.y < fighterData.terminalVelocity)
                fighter.SetVerticalVelocity(fighterData.terminalVelocity);
            
            // Fastfall
            if (MovementInput.y < 0)
            {
                fighter.SetVerticalVelocity(fighterData.terminalVelocity);
            }
        }
        
        public override void CheckTransitions()
        {
            base.CheckTransitions();
            
            // Check if on the ground
            if (fighter.IsGrounded && fighter.Velocity.y < 0)
            {
                stateMachine.ChangeState(State.Land);
            }
        }
    }
}