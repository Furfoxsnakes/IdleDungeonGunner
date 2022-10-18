using System;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

namespace Common
{
    public class PoolManager : SingletonMonobehaviour<PoolManager>
    {
        [SerializeField] private Pool[] _poolArray;
        private Transform _objectPoolTransform;  // will be the parent of the created pools
        private Dictionary<int, Queue<Component>> _poolDictionary = new Dictionary<int, Queue<Component>>();

        private void Start()
        {
            _objectPoolTransform = gameObject.transform;

            // populate the dictionary with the items in the pool array
            for (var i = 0; i < _poolArray.Length; i++)
            {
                CreatePool(_poolArray[i].Prefab, _poolArray[i].PoolSize, _poolArray[i].ComponentType);
            }
        }

        private void CreatePool(GameObject prefab, int poolSize, string componentType)
        {
            var poolKey = prefab.GetInstanceID();
            
            if (_poolDictionary.ContainsKey(poolKey)) return;
            
            var prefabName = prefab.name;
            
            // create a container to hold the child GOs for each pool
            var parentGameObject = new GameObject($"{prefabName} Anchor");
            parentGameObject.transform.SetParent(_objectPoolTransform);
            
            _poolDictionary.Add(poolKey, new Queue<Component>());

            // create the child GOs
            for (var i = 0; i < poolSize; i++)
            {
                var instance = Instantiate(prefab, parentGameObject.transform);
                instance.SetActive(false);
                // add the primary component of the prefab to the components queue of the dictionary
                // NOTE: REMEMBER TO USE {Namespace}.{TypeName} for GetComponent IN POOL ARRAY INSPECTOR
                var component = instance.GetComponent(Type.GetType(componentType));
                _poolDictionary[poolKey].Enqueue(component);
            }
        }

        /// <summary>
        /// Reuse a gameobject component in the pool
        /// </summary>
        /// <param name="prefab">The prefab containing the component</param>
        /// <param name="position">The world position of where the GameObject should appear when enabled</param>
        /// <param name="rotation">The rotation of the GameObject when enabled</param>
        /// <returns>The component of the GameObject to be reused</returns>
        public Component ReuseComponent(GameObject prefab, Vector3 position, Quaternion rotation)
        {
            var poolKey = prefab.GetInstanceID();

            if (!_poolDictionary.ContainsKey(poolKey))
            {
                Debug.Log($"No object pool for {prefab}");
                return null;
            }
            
            // get the next available component
            var componentToReturn = _poolDictionary[poolKey].Dequeue();
            // then add it immediately back to the pool
            _poolDictionary[poolKey].Enqueue(componentToReturn);

            // reset the game object
            var go = componentToReturn.gameObject;
            
            if (go.activeSelf)
                go.SetActive(false);

            componentToReturn.transform.position = position;
            componentToReturn.transform.rotation = rotation;
            go.transform.localScale = prefab.transform.localScale;

            // return the component
            return componentToReturn;
        }

        [Serializable]
        public struct Pool
        {
            public int PoolSize;
            public GameObject Prefab;
            public string ComponentType;
        }
        
#if UNITY_EDITOR
        private void OnValidate()
        {
            HelperUtilities.ValidateCheckEnumerableValues(this, nameof(_poolArray), _poolArray);
        }
#endif
    }
}