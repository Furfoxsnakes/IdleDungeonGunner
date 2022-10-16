using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DefaultNamespace.Input
{
    public class FindActionInputSystem : ActionTask
    {
        [SerializeField, ExposeField] private BBParameter<PlayerInput> bbPlayerInput;
        [SerializeField, ExposeField] private BBParameter<InputAction> bbInputAction;
        [SerializeField, ExposeField] private BBParameter<string> bbActionName;
        //This is called once each time the task is enabled.
        //Call EndAction() to mark the action as finished, either in success or failure.
        //EndAction can be called from anywhere.
        protected override void OnExecute()
        {
            bbInputAction.value=bbPlayerInput.value.actions.FindAction(bbActionName.value);
            EndAction(true);
        }
    }
}