using System;
using Character;
using UnityEngine;
using Utilities;

namespace DefaultNamespace.Arsenal
{
    public class Ammo : MonoBehaviour
    {
        private Rigidbody2D _rBody;
        private Vector3 _fireAngle;
        private AmmoDetailsSO _ammoDetails;
        private float _range;

        private void Awake()
        {
            _rBody = GetComponent<Rigidbody2D>();
        }

        public void Init(AmmoDetailsSO ammoDetails)
        {
            // transform.eulerAngles = lookAt;
            gameObject.SetActive(true);
            _ammoDetails = ammoDetails;
            _fireAngle = HelperUtilities.GetDirectionVectorFromAngle(transform.eulerAngles.z);
            _range = ammoDetails.Range;
        }

        private void FixedUpdate()
        {
            var distance = _fireAngle * _ammoDetails.Speed * Time.deltaTime;
            transform.position += distance;

            _range -= distance.magnitude;
            if (_range <= float.Epsilon)
                Disable();
        }

        private void OnCollisionEnter2D(Collision2D col)
        {

            var character = col.gameObject.GetComponent<Character.Character>();
            if (character == null) return;

            character.Health.TakeDamage(1);
            
            Disable();
        }

        private void Disable() => gameObject.SetActive(false);

    }
}