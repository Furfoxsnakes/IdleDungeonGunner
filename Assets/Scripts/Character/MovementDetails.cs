using System;
using Sirenix.OdinInspector;
using UnityEngine;
using Utilities;
using Random = UnityEngine.Random;

namespace Character
{
    [CreateAssetMenu(fileName = "MovementDetails_", menuName = "Scriptable Objects/Characters/Movement Details")]
    public class MovementDetails : SerializedScriptableObject
    {
        public string Name;
        [ShowInInspector, ValidateInput("IsGreaterThanZero")] private float _minMoveSpeed = 2f;
        [ShowInInspector, ValidateInput("IsGreaterThanZero")] private float _maxMoveSpeed = 2f;

        [Space(10), Header("Player Only Details")]
        [ValidateInput("IsPositiveValue")] public float RollCooldown;
        [HideInInspector] public float RollCooldownTime;
        [ValidateInput("IsGreaterThanZero")] public float RollDistance;
        [ValidateInput("IsGreaterThanZero")] public float RollSpeed;
        public bool CanRoll => RollCooldownTime <= 0;

        public float MoveSpeed
        {
            get
            {
                if (_maxMoveSpeed - _minMoveSpeed < 0.01f)
                    return _maxMoveSpeed;

                return Random.Range(_minMoveSpeed, _maxMoveSpeed);
            }
        }

        private void OnEnable()
        {
            RollCooldownTime = 0f;
        }

        public void CountdownCooldownTimer() => RollCooldownTime -= Time.deltaTime;

        private bool IsGreaterThanZero(int value) => HelperUtilities.IsGreaterThanZero(value);
        private bool IsPositiveValue(float value) => HelperUtilities.IsPositiveValue(value);

    }
}