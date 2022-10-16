using NodeCanvas.Framework;
using NodeCanvas.StateMachines;
using NodeCanvas.Tasks.Actions;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.InputSystem;

namespace StateMachine.States
{
    [Category("Character States")]
    public class MoveState : CharacterState
    {
        [RequiredField] public InputActionAsset _inputAction;
        private InputAction _moveAction;

        protected override void OnInit()
        {
            base.OnInit();
            // _inputAction.Enable();
            _moveAction = _inputAction.FindAction("Move");
        }

        protected override void OnEnter()
        {
            Character.Anim.SetBool("IsMoving", true);
        }

        protected override void OnExit()
        {
            Character.Anim.SetBool("IsMoving", false);
        }

        protected override void OnUpdate()
        {
            Character.Body.velocity = _moveAction.ReadValue<Vector2>() * Character.MovementDetails.MoveSpeed;
            
            if (_moveAction.ReadValue<Vector2>() == Vector2.zero)
                Finish();
        }
    }
}