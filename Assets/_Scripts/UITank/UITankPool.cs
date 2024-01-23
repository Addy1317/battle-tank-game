using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class UITankPool : MonoBehaviour
    {
        private GameObject prefab;
        private List<GameObject> pooledObjects = new List<GameObject>();

        public UITankPool(GameObject prefab, int initialPoolSize)
        {
            this.prefab = prefab;

            for (int i = 0; i < initialPoolSize; i++)
            {
                CreatePooledObject();
            }
        }

        public GameObject GetPooledObject()
        {
            foreach (var obj in pooledObjects)
            {
                if (!obj.activeInHierarchy)
                {
                    return obj;
                }
            }

            // If no inactive object is found, create a new one
            return CreatePooledObject();
        }

        private GameObject CreatePooledObject()
        {
            GameObject obj = Object.Instantiate(prefab);
            obj.SetActive(false);
            pooledObjects.Add(obj);
            return obj;
        }

        public void DeactivateAllObjects()
        {
            foreach (var obj in pooledObjects)
            {
                obj.SetActive(false);
            }
        }
    }
}