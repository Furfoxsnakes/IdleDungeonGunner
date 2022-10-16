using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class InputManager : MonoBehaviour
    {
        public Vector2 Direction;

        private void Update()
        {
            // Check for movement
            HandleMovementInput();
        }

        private void HandleMovementInput()
        {
            // Direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        }
    }

    public class MovementEventArgs : EventArgs
    {
        public Vector2 Movement;
    }
}