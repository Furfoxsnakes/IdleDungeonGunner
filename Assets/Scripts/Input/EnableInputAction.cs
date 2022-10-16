using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DefaultNamespace.Input
{
    public class EnableInputAction : ActionTask
    {
        [SerializeField,ExposeField] private BBParameter<PlayerInput> bbPlayerInput;

        protected override void OnExecute()
        {
            if (bbPlayerInput.value == null) bbPlayerInput.value = new PlayerInput();
            bbPlayerInput.value.enabled = true;
            EndAction(true);
        }
    }
}