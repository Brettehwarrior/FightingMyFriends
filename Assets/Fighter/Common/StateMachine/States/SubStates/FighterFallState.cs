using Fighter.Common.StateMachine.States.SuperStates;
using Fighter.Data;

namespace Fighter.Common.StateMachine.States.SubStates
{
    public class FighterFallState : FighterAirState
    {
        public FighterFallState(Common.Fighter fighter, FighterStateMachine stateMachine, FighterData fighterData, string animationName) : base(fighter, stateMachine, fighterData, animationName)
        {
        }

    }
}