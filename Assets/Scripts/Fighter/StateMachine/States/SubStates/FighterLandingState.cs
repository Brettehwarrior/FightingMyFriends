using DefaultNamespace;
using Fighter.Data;

namespace Fighter.StateMachine.States.SubStates
{
    public class FighterLandingState : FighterGroundedState
    {
        public FighterLandingState(Fighter fighter, FighterStateMachine stateMachine, FighterData fighterData, string animationName) : base(fighter, stateMachine, fighterData, animationName)
        {
        }

        public override void UpdateLogic()
        {
            base.UpdateLogic();
            
            if (fighter.Anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
            {
                stateMachine.ChangeState(fighter.States.IdleState);
            }
        }
    }
}