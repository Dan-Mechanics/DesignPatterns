using System;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectPoolPattern
{
    public class ObjectPool<T> where T : IPoolable
    {
        private readonly List<T> inactivePool = new List<T>();
        private readonly List<T> activePool = new List<T>();

        public T AddItemToPool()
        {
            T instance = (T)Activator.CreateInstance(typeof(T));
            inactivePool.Add(instance);
            Debug.Log("A New Item was added to the pool");

            return instance;
        }

        public T AddGameObjectToPool(GameObject go)
        {
            T instance = UnityEngine.Object.Instantiate(go).GetComponent<T>();
            inactivePool.Add(instance);
            Debug.Log("A New Item was added to the pool");

            return instance;
        }

        public T RequestObject()
        {
            if (inactivePool.Count > 0)
                return ActivateItem(inactivePool[0]);

            return ActivateItem(AddItemToPool());
        }

        public T RequestGameObject(GameObject go)
        {
            if (inactivePool.Count > 0)
                return ActivateItem(inactivePool[0]);

            return ActivateItem(AddGameObjectToPool(go));
        }

        public T ActivateItem(T item)
        {
            item.Enable();
            item.Active = true;

            if (inactivePool.Contains(item))
                inactivePool.Remove(item);

            activePool.Add(item);
            return item;
        }

        public void ReturnObjectToPool(T item)
        {
            if (activePool.Contains(item))
                activePool.Remove(item);

            item.Disable();
            item.Active = false;
            inactivePool.Add(item);
        }

        public void Dump() 
        {
            for (int i = 0; i < activePool.Count; i++)
            {
                activePool[i].Dump();
            }

            for (int i = 0; i < inactivePool.Count; i++)
            {
                inactivePool[i].Dump();
            }

            activePool.Clear();
            inactivePool.Clear();

            // destroy this ...
        }
    }
}