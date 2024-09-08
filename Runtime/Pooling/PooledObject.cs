using UnityEngine;

namespace Slax.Utils
{
    /// <summary>
    /// A wrapper class that automatically returns itself to the pool after a predefined event (e.g., after a certain time or after a collision)
    /// </summary>
    public class PooledObject : MonoBehaviour
    {
        /// <summary>
        /// The pool that this object belongs to
        /// </summary>
        public ObjectPool<PooledObject> Pool { get; set; }

        public void ReturnToPoolAfterTime(float time)
        {
            Invoke(nameof(ReturnToPool), time);
        }

        public void ReturnToPool()
        {
            Pool.ReturnToPool(this);
        }
    }
}