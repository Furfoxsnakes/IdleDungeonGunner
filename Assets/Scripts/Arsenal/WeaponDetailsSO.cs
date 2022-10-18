using Sirenix.OdinInspector;
using UnityEngine;

namespace DefaultNamespace.Arsenal
{
    [CreateAssetMenu(fileName = "WeaponDetails_", menuName = "Scriptable Objects/Weapons/Weapon Details")]
    public class WeaponDetailsSO : SerializedScriptableObject
    {
        [Space(10)] [Header("WEAPON BASE DETAILS")]
        public string Name;
        [Tooltip("Make sure the sprite has 'Generate Physics Shape' selected when imported")]
        public Sprite Sprite;

        [Space(10)] [Header("WEAPON CONFIG")] 
        [Tooltip("The offset position for the end of the weapon from the sprite pivot point")]
        public Vector3 ShootPosition;
        // TODO: Add ammo type/details
        public AmmoDetailsSO AmmoDetails;
        //public WeaponShootEffectSO ShootEffect;

        [Space(10)] [Header("OPERATING VALUES")]
        public bool HasInfiniteAmmo;
        public bool HasInfiniteClip;    // Can be handled by ClipCapacity (eg: -1 = infinite)
        public int ClipCapacity = 6;
        public int AmmoCapacity = 100;
        public float FireRate = 0.2f;
        [Tooltip("Some weapon require you to hold fire down to charge. Eg: Laser weapons")]
        public float PrechargeTime;    // Some weapon require you to hold fire down to charge
        public float ReloadTime;

        // [Space(10)] [Header("AUDIO")] 
        //public SoundEffectSO FiringSoundEffect;
        //public SoundEffectSO ReloadSoundEffect;
    }
}