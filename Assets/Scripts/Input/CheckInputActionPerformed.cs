using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DefaultNamespace.Input
{
    public class CheckInputActionPerformed : ConditionTask
    {
        [SerializeField, ExposeField] private BBParameter<InputAction> bbInputAction;
        
        protected override void OnEnable()
        {
            bbInputAction.value.performed += OnPerformed;
        }

        protected override void OnDisable()
        {
            bbInputAction.value.performed -= OnPerformed;
        }

        protected override bool OnCheck()
        {
            return false;
        }

        private void OnPerformed(InputAction.CallbackContext obj)
        {
            YieldReturn(true);
        }
    }
}