using System;
using Fighter.Data;

namespace Fighter.StateMachine.States.SuperStates
{
    public class FighterAirState : FighterState
    {
        public FighterAirState(global::Fighter.StateMachine.Fighter fighter, FighterStateMachine stateMachine, FighterData fighterData, string animationName) : base(fighter, stateMachine, fighterData, animationName)
        {
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            
            // Air movement
            
            if (Math.Sign(MovementInput.x) != Math.Sign(fighter.Velocity.x) || Math.Abs(fighter.Velocity.x) < fighterData.maxAirSpeed)
                fighter.SetHorizontalVelocity(fighter.Velocity.x + MovementInput.x * fighterData.airAcceleration);
        }
    }
}