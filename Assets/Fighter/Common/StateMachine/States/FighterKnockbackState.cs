using Fighter.Data;

namespace Fighter.Common.StateMachine.States
{
    public class FighterKnockbackState : FighterState
    {
        public FighterKnockbackState(Fighter fighter, FighterStateMachine stateMachine, FighterData fighterData, string animationName) : base(fighter, stateMachine, fighterData, animationName)
        {
        }

        public override void Enter()
        {
            base.Enter();
            
        }
    }
}