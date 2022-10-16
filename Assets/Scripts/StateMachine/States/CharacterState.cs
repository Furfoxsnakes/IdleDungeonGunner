using System.ComponentModel;
using NodeCanvas.StateMachines;

namespace StateMachine.States
{
    [Category("Character States")]
    public class CharacterState : FSMState
    {
        protected Character.Character Character;

        protected override void OnInit()
        {
            Character = graphAgent.GetComponent<Character.Character>();
        }
    }
}