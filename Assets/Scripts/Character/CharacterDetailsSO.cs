using System;
using Sirenix.OdinInspector;
using UnityEngine;
using Utilities;

namespace Character
{
    [CreateAssetMenu(fileName = "Health", menuName = "Scriptable Objects/Character/Health")]
    public class CharacterDetailsSO : ScriptableObject
    {
        public string Name;
        [ValidateInput("IsGreaterThanZero")] public int Health;

        private bool IsGreaterThanZero(int value) => HelperUtilities.IsGreaterThanZero(value);
    }
}