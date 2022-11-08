using System;
using System.ComponentModel;
using UnityEngine;

namespace Utilities
{
    [System.Serializable]
    public class SpawnableObject<T>
    {
        public T Object;
        [Tooltip("Time in Seconds after this spawner has started to spawn this object")]
        public int Time;
        [Range(1,100)] public int NumToSpawn = 1;
        [Range(0, 2)] public float AllowableDistanceToSpawn;
    }
}