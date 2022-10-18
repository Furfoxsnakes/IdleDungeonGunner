using System;
using UnityEngine;

namespace Character
{
    [RequireComponent(typeof(Character))]
    [DisallowMultipleComponent]
    public class PlayerController : MonoBehaviour
    {
        private Character _character;

        private void Awake()
        {
            _character = GetComponent<Character>();
        }
    }
}