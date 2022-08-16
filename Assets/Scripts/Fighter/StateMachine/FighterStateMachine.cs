using UnityEngine;

namespace Fighter.StateMachine
{
    public class FighterStateMachine
    {
        public FighterState CurrentState { get; private set; }

        public void Initialize(FighterState startingState)
        {
            CurrentState = startingState;
            CurrentState.Enter();
        }
        
        public void ChangeState(FighterState state)
        {
            CurrentState.Exit();
            CurrentState = state;
            CurrentState.Enter();
        }
    }
}