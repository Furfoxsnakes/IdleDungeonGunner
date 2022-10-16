using DefaultNamespace;
using UnityEngine;

namespace StateMachine.States
{
    public class Idle : State
    {
        private Vector2 _direction;
        
        public override void Do()
        {
            if (Engine.E.InputManager.Direction != Vector2.zero)
                Complete = true;
            
            base.Do();
        }

        public override void Enter(bool debug = false)
        {
            base.Enter(debug);
            Core.Anim.SetBool("IsMoving", false);
            Core.Anim.SetBool("IsIdle", true);
        }
    }
}