using System;
using UnityEngine;

namespace StateMachine
{
    public class StateMachine : MonoBehaviour
    {
        public State CurrentState => _currentState;
        private State _currentState;
        private bool _inTransition;
        [SerializeField] private bool _debug;

        public void SetState(State state)
        {
            if (_inTransition || state == _currentState) return;

            _inTransition = true;
            _currentState?.Exit(_debug);
            _currentState = state;
            _currentState?.Enter(_debug);

            _inTransition = false;
        }

        public virtual void Update() => _currentState.Do();

        public virtual void FixedUpdate() => _currentState.FixedDo();
    }
}