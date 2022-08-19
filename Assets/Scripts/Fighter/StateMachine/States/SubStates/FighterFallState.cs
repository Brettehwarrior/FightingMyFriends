using DefaultNamespace;
using Fighter.Data;

namespace Fighter.StateMachine.States.SubStates
{
    public class FighterFallState : FighterAirState
    {
        public FighterFallState(Fighter fighter, FighterStateMachine stateMachine, FighterData fighterData, string animationName) : base(fighter, stateMachine, fighterData, animationName)
        {
        }
    }
}