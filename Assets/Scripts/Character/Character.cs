using System;
using UnityEngine;
using StateMachine;
using UnityEngine.InputSystem;

namespace Character
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(SpriteRenderer))]
    [DisallowMultipleComponent]
    public class Character : MonoBehaviour
    {
        [HideInInspector] public Rigidbody2D Body;
        [HideInInspector] public Animator Anim;
        public Vector2 Pos => transform.position;

        public Character Target;

        [Space(10)] [Header("Character Stats")]
        public MovementDetails MovementDetails;

        public float MoveSpeed => MovementDetails.MoveSpeed;

        public bool CanRoll => MovementDetails.RollCooldownTime <= 0;

        public event EventHandler<Collider2D> OnCollision;

        private void Awake()
        {
            Anim = GetComponent<Animator>();
            Body = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            // count down roll cooldown timer
            MovementDetails.CountdownCooldownTimer();
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            OnCollision?.Invoke(this, col.collider);
        }
    }
}