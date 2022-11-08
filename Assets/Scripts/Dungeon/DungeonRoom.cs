using System;
using System.Collections.Generic;
using DefaultNamespace.Dungeon;
using Sirenix.OdinInspector;
using UnityEngine;
using Utilities;

namespace Dungeon
{
    public class DungeonRoom : MonoBehaviour
    {
        public List<Character.Character> SpawnedEnemies => _spawnedEnemies;
        [ShowInInspector] private List<Character.Character> _spawnedEnemies = new();
        
        [SerializeField, Required] private Doorway[] _doorways;
        [SerializeField, Required] private ObjectSpawner[] _spawners;

        public bool IsCleared = false;

        private void Start()
        {
            foreach (var doorway in _doorways)
                doorway.Lock();
        }

        public void AddSpawnedEnemy(Character.Character enemy)
        {
            if (_spawnedEnemies.Contains(enemy))
            {
                Debug.LogError($"Enemy {enemy} already in spawned list");
                return;
            }
            
            _spawnedEnemies.Add(enemy);
        }

        public void RemoveSpawnedEnemy(Character.Character enemy)
        {
            if (!_spawnedEnemies.Contains(enemy))
            {
                Debug.LogError($"Enemy {enemy} is not in spawned list.");
                return;
            }

            _spawnedEnemies.Remove(enemy);

            if (CheckIfRoomCleared())
            {
                IsCleared = true;
                foreach (var doorway in _doorways)
                    doorway.UnLock();
            }
        }

        /// <summary>
        /// Checks the state of the room to see if it's been cleared
        /// </summary>
        /// <returns>Returns true if there are no more spawned enemies and all spawners have stopped</returns>
        private bool CheckIfRoomCleared()
        {
            var roomIsClear = true;

            foreach (var spawner in _spawners)
            {
                if (_spawnedEnemies.Count > 0)
                    roomIsClear = false;
                
                if (spawner.IsStarted)
                {
                    roomIsClear = false;
                    break;
                }
            }

            return roomIsClear;
        }
    }
}