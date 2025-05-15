using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns
{
    public class GameObjectPool
    {
        private readonly GameObject prefab;
        private readonly List<GameObject> active = new List<GameObject>();
        private readonly List<GameObject> inactive = new List<GameObject>();

        public GameObjectPool(GameObject prefab)
        {
            if (prefab.GetComponent<PoolableGameObject>() == null)
            {
                Debug.LogError("prefab.GetComponent<PoolableGameObject>() == null");
                prefab.AddComponent<PoolableGameObject>();
            }

            this.prefab = prefab;
        }

        public GameObject GetFromPool()
        {
            if (inactive.Count > 0)
                return ActivateItem(inactive[0]);

            return ActivateItem(SpawnNewGameOjbect());
        }

        public void DumpAll() 
        {
            active.ForEach(x => Object.Destroy(x));
            active.Clear();

            inactive.ForEach(x => Object.Destroy(x));
            inactive.Clear();
        }

        public void GiveToPool(GameObject go)
        {
            // We cant add something if it dosnt exist to us.
            if (!active.Contains(go))
                return;

            active.Remove(go);
            go.SetActive(false);
            inactive.Add(go);
        }

        private GameObject SpawnNewGameOjbect()
        {
            GameObject go = Object.Instantiate(prefab);
            go.GetComponent<PoolableGameObject>().Setup(this);
            go.name = prefab.name;

            return go;
        }

        private GameObject ActivateItem(GameObject go)
        {
            go.SetActive(true);
            inactive.Remove(go);
            active.Add(go);

            return go;
        }
    }
}