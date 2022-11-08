using System;
using System.Collections;
using System.Collections.Generic;
using Common;
using JetBrains.Annotations;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Utilities
{
    public class ObjectSpawner : MonoBehaviour
    {
        [SerializeField, Tooltip("Start the timer when the object is ready in the scene")] private bool _startOnReady;
        [Tooltip("Denotes if the timer has been started for this spawner")] public bool IsStarted;
        private float _timer;
        
        [SerializeField, Required] private SpawnableObject<GameObject>[] _objectsArray;
        private Queue<SpawnableObject<GameObject>> _spawnQueue;

        private SpawnableObject<GameObject> _nextUp;

        private void Start()
        {
            PopulateSpawnQueue();
            if (_startOnReady)
                IsStarted = true;
        }

        private void FixedUpdate()
        {
            ProcessTimer();
        }

        private void PopulateSpawnQueue()
        {
            if (_objectsArray == null) return;
            
            // sort the object by their Time property
            _objectsArray.Sort(SortByTime);
            
            // add sorted objects into a queue
            _spawnQueue = new Queue<SpawnableObject<GameObject>>();
            foreach (var spawnableObject in _objectsArray)
                _spawnQueue.Enqueue(spawnableObject);

            _nextUp = _spawnQueue.Dequeue();
        }

        private void ProcessTimer()
        {
            if (!IsStarted) return;

            if (_timer >= _nextUp.Time)
                SpawnObject(_nextUp);

            _timer += Time.deltaTime;
        }

        private void SpawnObject(SpawnableObject<GameObject> spawnableObject)
        {
            // for (int i = 0; i < spawnableObject.NumToSpawn; i++)
            // {
            //     var posToSpawn = new Vector2();
            //     posToSpawn.x = transform.position.x + Random.Range(-spawnableObject.AllowableDistanceToSpawn,
            //         spawnableObject.AllowableDistanceToSpawn);
            //     posToSpawn.y = transform.position.y + Random.Range(-spawnableObject.AllowableDistanceToSpawn,
            //         spawnableObject.AllowableDistanceToSpawn);
            //     var spawnedObject = PoolManager.Instance.ReuseComponent(spawnableObject.Object, posToSpawn, Quaternion.identity);
            //     spawnedObject.gameObject.SetActive(true);
            // }

            StartCoroutine(SpawnObjectsAtRandomInterval(spawnableObject));
            
            if (_spawnQueue.Count == 0)
            {
                IsStarted = false;
                return;
            }
            
            _nextUp = _spawnQueue.Dequeue();
        }

        private int SortByTime(SpawnableObject<GameObject> x, SpawnableObject<GameObject> y)
        {
            return x.Time.CompareTo(y.Time);
        }

        private IEnumerator SpawnObjectsAtRandomInterval(SpawnableObject<GameObject> spawnableObject)
        {
            var numSpawned = 0;
            while (numSpawned < spawnableObject.NumToSpawn)
            {
                var posToSpawn = new Vector2();
                posToSpawn.x = transform.position.x + Random.Range(-spawnableObject.AllowableDistanceToSpawn,
                    spawnableObject.AllowableDistanceToSpawn);
                posToSpawn.y = transform.position.y + Random.Range(-spawnableObject.AllowableDistanceToSpawn,
                    spawnableObject.AllowableDistanceToSpawn);
                var spawnedObject = PoolManager.Instance.ReuseComponent(spawnableObject.Object, posToSpawn, Quaternion.identity);
                spawnedObject.gameObject.SetActive(true);
                Engine.E.CurrentDungeonRoom.AddSpawnedEnemy(spawnedObject as Character.Character);

                numSpawned++;
                
                var randomInterval = Random.Range(0.05f, 0.15f);
                yield return new WaitForSeconds(randomInterval);
            }
        }
    }
}