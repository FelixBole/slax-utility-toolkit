using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Slax.Utils
{
    /// <summary>
    /// This transforms the static instance into a basic singleton. This will destroy any new
    /// versions created, leaving the original instance intact
    /// </summary>
    public abstract class Singleton<T> : StaticInstance<T> where T : MonoBehaviour
    {
        protected override void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }
            base.Awake();
        }
    }
}
