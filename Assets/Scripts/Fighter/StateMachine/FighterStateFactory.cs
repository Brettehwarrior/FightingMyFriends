using System.Collections.Generic;
using Fighter.Data;
using Fighter.StateMachine.States.SubStates;

namespace Fighter.StateMachine
{
    public class FighterStateFactory
    {
        public FighterState IdleState { get; private set; }
        public FighterState WalkState { get; private set; }
        public FighterState JumpState { get; private set; }
        public FighterState FallState { get; private set; }
        public FighterState LandingState { get; private set; }
        
        public FighterStateFactory(Fighter fighter, FighterStateMachine stateMachine, FighterData data)
        {
            IdleState = new FighterIdleState(fighter, stateMachine, data, "Jerma Idle");
            WalkState = new FighterWalkState(fighter, stateMachine, data, "Jerma Walk");
            JumpState = new FighterJumpState(fighter, stateMachine, data, "Jerma Jump");
            FallState = new FighterFallState(fighter, stateMachine, data, "Jerma Fall");
            LandingState = new FighterLandingState(fighter, stateMachine, data, "Jerma Landing");
        }
    }
}