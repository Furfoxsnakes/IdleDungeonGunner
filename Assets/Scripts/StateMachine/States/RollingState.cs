using System.Collections;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using Utilities;

namespace StateMachine.States
{
    public class RollingState : CharacterState
    {
        [RequiredField] public InputActionAsset _inputAction;
        private InputAction _rollAction;
        private InputAction _moveAction;

        private Coroutine _rollCoroutine;
        private float _timer;

        private Vector2 _targetPos;

        protected override void OnInit()
        {
            base.OnInit();
            _moveAction = _inputAction.FindAction("Move");
        }

        protected override void OnEnter()
        {
            Character.Anim.SetBool("IsRolling", true);
            //_targetPos = (Vector2)Character.transform.position + _moveAction.ReadValue<Vector2>() * Character.MovementDetails.RollDistance;
            //Character.Body.velocity = _moveAction.ReadValue<Vector2>() * Character.MovementDetails.RollSpeed;
            var mousePos = HelperUtilities.GetMouseWorldPos();
            var playerAngle = mousePos - Character.transform.position;
            var targetAngleDegrees = HelperUtilities.GetAngleFromVector(playerAngle);
            var targetAimDirection = HelperUtilities.GetDirectionVectorFromAngle(targetAngleDegrees);
            _targetPos = Character.transform.position + targetAimDirection * Character.MovementDetails.RollDistance;
            Character.Body.velocity = targetAimDirection * Character.MovementDetails.RollSpeed;
            Character.MovementDetails.RollCooldownTime = Character.MovementDetails.RollCooldown;
        }

        protected override void OnExit()
        {
            Character.Anim.SetBool("IsRolling", false);
        }

        protected override void OnUpdate()
        {
            var distance = Vector2.Distance(Character.transform.position, _targetPos);
            Debug.Log(distance);
            if ( distance<= 0.2f)
                Finish();
        }
    }
}