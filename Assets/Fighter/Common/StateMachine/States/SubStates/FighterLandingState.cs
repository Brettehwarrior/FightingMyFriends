using Fighter.Data;
using Fighter.StateMachine.States.SuperStates;

namespace Fighter.StateMachine.States.SubStates
{
    public class FighterLandingState : FighterGroundedState
    {
        public FighterLandingState(Common.Fighter fighter, FighterStateMachine stateMachine, FighterData fighterData, string animationName) : base(fighter, stateMachine, fighterData, animationName)
        {
        }
        public override void CheckTransitions()
        {
            if (fighter.Anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
            {
                stateMachine.ChangeState(State.Idle);
            }
        }
    }
}