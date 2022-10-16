using System.ComponentModel;
using NodeCanvas.StateMachines;

namespace StateMachine.States
{
    [Category("Character States")]
    public class IdleState : CharacterState
    {
        private Character.Character _character => graphAgent.GetComponent<Character.Character>();
        
        protected override void OnEnter()
        {
            _character.Anim.SetBool("IsIdle", true);
        }

        protected override void OnExit()
        {
            Character.Anim.SetBool("IsIdle", false);
        }
    }
}