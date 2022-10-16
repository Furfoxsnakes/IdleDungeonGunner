using UnityEngine;

namespace StateMachine
{
    public class State : MonoBehaviour
    {
        public bool Complete;
        protected Character.Character Core => GetComponentInParent<Character.Character>();

        public State ChildState;

        public virtual void Enter(bool debug = false)
        {
            Complete = false;
            
            if (debug)
                Debug.Log($"Entered {name} state!");
        }

        public virtual void Exit(bool debug = false)
        {
            if (debug)
                Debug.Log($"Exited {name} state!");
        }

        public virtual void Do()
        {
            
        }

        public virtual void FixedDo()
        {
            
        }

        // public void SetState(State state) => Core.SetState(state);
    }
}