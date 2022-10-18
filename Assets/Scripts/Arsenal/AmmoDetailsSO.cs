using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace DefaultNamespace.Arsenal
{
    [CreateAssetMenu(fileName = "AmmoDetails_", menuName = "Scriptable Objects/Weapons/Ammo Details")]
    public class AmmoDetailsSO : SerializedScriptableObject
    {
        [Header("BASIC DETAILS")] 
        public string Name;
        public bool IsPlayerAmmo;
        public Sprite Sprite;
        public GameObject[] Prefabs;    // allows for multiple prefabs/looks/types
        public Material Material;
        //public AmmoHitEffectSO HitEffect;

        [Space(10)] 
        [Header("BASE PARAMETERS")]
        public int Damage = 1;
        public float MinSpeed = 20f;
        public float MaxSpeed = 20f;

        public float Speed
        {
            get
            {
                if (MaxSpeed == MinSpeed)
                    return MaxSpeed;
                
                return Random.Range(MinSpeed, MaxSpeed);
            }
        }
        public float Range = 20f;

        [Space(10)]
        [Header("SPREAD DETAILS")] 
        public float SpreadMin;
        public float SpreadMax;

        [Space(10)] [Header("SPAWN DETAILS")] 
        public int SpawnAmountMin = 1;
        public int SpawnAmountMax = 1;
        public float SpawnIntervalMin;
        public float SpawnIntervalMax;

        [Space(10)] [Header("TRAIL DETAILS")]
        public bool IsTrailAmmo;
        public float TrailLifeTime = 3f;
        public Material TrailMaterial;
        [Range(0f, 1f)]public float TrailStartWidth = 0.5f;
        [Range(0f, 1f)]public float TrailEndWidth = 0.5f;
    }
}