using System.Collections.Generic;
using DefaultNamespace.Enums;
using Sirenix.OdinInspector;
using UnityEngine;

namespace DefaultNamespace.Dungeon
{
    [CreateAssetMenu(fileName = "RoomDetails_", menuName = "Scriptable Objects/Dungeon/Room Details")]
    public class RoomDetailsSO : SerializedScriptableObject
    {
        [HideInInspector] public string GUID;

        [Header("ROOM PREFAB")]
        public GameObject Prefab;

        [HideInInspector] public GameObject PreviousPrefab; // used to regenerate the GUID if this SO is copied and the prefab is changed

        [Space(10)] [Header("ROOM CONFIG")] 
        [SerializeField] public Difficulty Difficulty;
        [SerializeField] public RoomType RoomType;
        [SerializeField] public List<Doorway> Doorways;
        public Vector2Int[] SpawnPositions;
    }
}