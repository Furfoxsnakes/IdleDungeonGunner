using System;
using System.Linq;
using Common;
using Sirenix.OdinInspector;
using UnityEngine;
using Utilities;

namespace DefaultNamespace.Arsenal
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private WeaponDetailsSO _weaponDetails;
        public float FireRate => _weaponDetails.FireRate;

        private Character.Character _owner;
        public Character.Character Owner => _owner;

        private float _fireCountdown;

        private void Awake()
        {
            _owner = GetComponentInParent<Character.Character>();
        }

        private void FixedUpdate()
        {
            _fireCountdown -= Time.deltaTime;
        }

        public void Fire()
        {
            if (_fireCountdown > 0) return;
            
            var projectile = PoolManager.Instance.ReuseComponent(_weaponDetails.AmmoDetails.Prefabs.First(),
                transform.position + _weaponDetails.ShootPosition, transform.rotation);
            projectile.GetComponent<Ammo>().Init(_weaponDetails.AmmoDetails);

            _fireCountdown = _weaponDetails.FireRate;
        }

        public void LookAt(Transform target)
        {
            // var angleToTarget = Vector3.Angle(transform.position, target.position);
            var weaponAngle = target.position - transform.position;
            var weaponAngleDegress = HelperUtilities.GetAngleFromVector(weaponAngle);
            transform.eulerAngles = new Vector3(0, 0, weaponAngleDegress);
            if (weaponAngleDegress is > 0 and < 90 or < 0 and > -90)
                transform.localScale = new Vector3(1, 1, 1);
            else
                transform.localScale = new Vector3(1, -1, 1);
        }
    }
}