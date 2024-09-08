using System.Collections.Generic;
using UnityEngine;

namespace Slax.Utils
{
    /// <summary>
    /// Pool individual components within objects rather than full GameObjects. 
    /// Useful when you want to pool specific components like `Rigidbody` or `Collider` for reuse within different objects.
    /// </summary>
    public class ComponentPool<T> where T : Component
    {
        private readonly Queue<T> pool = new Queue<T>();
        private readonly T prefab;

        public ComponentPool(T prefab, int initialSize)
        {
            this.prefab = prefab;
            for (int i = 0; i < initialSize; i++)
            {
                AddToPool();
            }
        }

        private void AddToPool()
        {
            T component = Object.Instantiate(prefab);
            component.gameObject.SetActive(false);
            pool.Enqueue(component);
        }

        public T GetFromPool()
        {
            if (pool.Count == 0)
            {
                AddToPool();
            }

            T component = pool.Dequeue();
            component.gameObject.SetActive(true);
            return component;
        }

        public void ReturnToPool(T component)
        {
            component.gameObject.SetActive(false);
            pool.Enqueue(component);
        }
    }
}