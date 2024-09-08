using System.Collections.Generic;
using UnityEngine;

namespace Slax.Utils
{
    /// <summary>
    /// Generic object pool for MonoBehaviour objects in Unity. 
    /// This class allows for recycling of objects to optimize memory usage and performance.
    /// </summary>
    /// <typeparam name="T">The type of MonoBehaviour object to pool.</typeparam>
    public class ObjectPool<T> where T : MonoBehaviour
    {
        /// <summary>
        /// Queue that stores pooled objects.
        /// </summary>
        private readonly Queue<T> pool;

        /// <summary>
        /// Prefab used to instantiate new objects when the pool is empty.
        /// </summary>
        private readonly T prefab;

        /// <summary>
        /// Optional parent transform to organize pooled objects in the hierarchy.
        /// </summary>
        private readonly Transform parentTransform;

        /// <summary>
        /// Initializes the object pool with the given prefab and an initial size.
        /// </summary>
        /// <param name="prefab">The prefab to pool.</param>
        /// <param name="initialSize">The number of objects to instantiate initially.</param>
        /// <param name="parent">Optional parent transform to hold pooled objects.</param>
        public ObjectPool(T prefab, int initialSize, Transform parent = null)
        {
            pool = new Queue<T>();
            this.prefab = prefab;
            parentTransform = parent;

            // Preload objects
            for (int i = 0; i < initialSize; i++)
            {
                AddToPool();
            }
        }

        /// <summary>
        /// Instantiates a new object and adds it to the pool.
        /// </summary>
        private void AddToPool()
        {
            T obj = Object.Instantiate(prefab, parentTransform);
            obj.gameObject.SetActive(false);
            pool.Enqueue(obj);
        }

        /// <summary>
        /// Retrieves an object from the pool, activating it in the scene.
        /// Instantiates a new object if the pool is empty.
        /// </summary>
        /// <returns>A pooled object.</returns>
        public T GetFromPool()
        {
            if (pool.Count == 0)
            {
                AddToPool();
            }

            T obj = pool.Dequeue();
            obj.gameObject.SetActive(true);
            return obj;
        }

        /// <summary>
        /// Returns an object to the pool and deactivates it.
        /// </summary>
        /// <param name="obj">The object to return to the pool.</param>
        public void ReturnToPool(T obj)
        {
            obj.gameObject.SetActive(false);
            pool.Enqueue(obj);
        }
    }
}
