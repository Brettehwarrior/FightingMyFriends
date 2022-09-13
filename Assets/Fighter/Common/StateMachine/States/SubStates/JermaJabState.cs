using Fighter.Common.StateMachine.States.SuperStates;
using Fighter.Data;

namespace Fighter.Common.StateMachine.States.SubStates
{
    public class JermaJabState : FighterGroundedState
    {
        public JermaJabState(Fighter fighter, FighterStateMachine stateMachine, FighterData fighterData, string animationName) : base(fighter, stateMachine, fighterData, animationName)
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