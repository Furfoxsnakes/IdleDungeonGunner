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
        
        [Header("Character States")]
        [SerializeField] private State Idle;
        [SerializeField] private State Move;

        [Space(10)] [Header("Character Stats")]
        public MovementDetails MovementDetails;

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
            MovementDetails?.CountdownCooldownTimer();
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            OnCollision?.Invoke(this, col.collider);
        }

        // OLD STATE MACHINE - KEEPING JUST IN CASE
        // PROBABLY DON'T NEED ANY MORE
        // private void Start()
        // {
        //     SetState(Idle);
        // }
        //
        // public override void Update()
        // {
        //     if (CurrentState.Complete)
        //         if (CurrentState == Idle)
        //             SetState(Move);
        //         else if (CurrentState == Move)
        //             SetState(Idle);
        //     
        //     base.Update();
        // }
        //
        // public void SetNextState()
        // {
        //     if (CurrentState == Idle)
        //         SetState(Move);
        //     else if (CurrentState == Move)
        //         SetState(Idle);
        // }
    }
}