using UnityEngine;

namespace StateMachine.States
{
    public class Move : State
    {
        public override void Do()
        {
            if (Engine.E.InputManager.Direction == Vector2.zero)
                Complete = true;

            Core.Body.velocity = Engine.E.InputManager.Direction * Core.MovementDetails.MoveSpeed; 
            
            base.Do();
        }

        public override void Enter(bool debug = false)
        {
            base.Enter(debug);
            Core.Anim.SetBool("IsIdle", false);
            Core.Anim.SetBool("IsMoving", true);
        }
    }
}