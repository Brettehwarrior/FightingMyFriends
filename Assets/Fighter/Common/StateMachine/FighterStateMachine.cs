using System.Collections.Generic;
using Fighter.Common.StateMachine.States.SubStates;
using Fighter.Data;

namespace Fighter.Common.StateMachine
{
    public enum State
    {
        Idle,
        Walk,
        Jump,
        Land,
        Fall
    }
    
    public class FighterStateMachine
    {
        private Dictionary<State, FighterState> _states;

        public FighterState CurrentState { get; private set; }

        public void Initialize(State startingStateType, Fighter fighter, FighterData data)
        {
            _states = new Dictionary<State, FighterState>
            {
                {State.Idle, new FighterIdleState(fighter, this, data, "Jerma Idle")},
                {State.Walk, new FighterWalkState(fighter, this, data, "Jerma Walk")},
                {State.Jump, new FighterJumpState(fighter, this, data, "Jerma Jump")},
                {State.Land, new FighterLandingState(fighter, this, data, "Jerma Landing")},
                {State.Fall, new FighterFallState(fighter, this, data, "Jerma Fall")},
            };
            
            CurrentState = _states[startingStateType];
            CurrentState.Enter();
        }
        
        public void ChangeState(State stateType)
        {
            CurrentState.Exit();
            _states[stateType].Enter();
            CurrentState = _states[stateType];
        }
    }
}