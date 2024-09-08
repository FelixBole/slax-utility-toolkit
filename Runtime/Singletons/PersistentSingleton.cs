using UnityEngine;

namespace Slax.Utils
{
    /// <summary>
    /// A generic singleton class that persists across scene loads in Unity.
    /// This singleton ensures that there is only one instance of the specified component type <typeparamref name="T"/> and prevents destruction between scene loads.
    /// </summary>
    /// <typeparam name="T">The type of component that will be the singleton instance.</typeparam>
    public class PersistentSingleton<T> : MonoBehaviour where T : Component
    {
        /// <summary>
        /// If true, this singleton will detach itself from any parent GameObject on awake.
        /// Useful if the singleton is instantiated as part of another hierarchy but needs to exist independently.
        /// </summary>
        [Tooltip("If this is true, this singleton will auto detach if it finds itself parented on awake")]
        public bool UnparentOnAwake = true;

        /// <summary>
        /// Checks if there is an existing instance of this singleton.
        /// </summary>
        public static bool HasInstance => instance != null;

        /// <summary>
        /// Provides the current instance of the singleton.
        /// </summary>
        public static T Current => instance;

        /// <summary>
        /// The static reference to the singleton instance.
        /// </summary>
        protected static T instance;

        /// <summary>
        /// Gets the singleton instance. If no instance exists, it finds or creates a new one.
        /// </summary>
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindFirstObjectByType<T>(); // Find an existing instance in the scene.
                    if (instance == null)
                    {
                        GameObject obj = new GameObject(); // Create a new GameObject if none exists.
                        obj.name = typeof(T).Name + "AutoCreated";
                        instance = obj.AddComponent<T>();
                    }
                }

                return instance;
            }
        }

        /// <summary>
        /// Called when the script instance is being loaded.
        /// Initializes the singleton and handles the unparenting logic.
        /// </summary>
        protected virtual void Awake() => InitializeSingleton();

        /// <summary>
        /// Initializes the singleton instance. Ensures that only one instance exists and persists across scene loads.
        /// If <see cref="UnparentOnAwake"/> is true, the object will unparent itself on awake.
        /// </summary>
        protected virtual void InitializeSingleton()
        {
            if (!Application.isPlaying)
            {
                return;
            }

            if (UnparentOnAwake)
            {
                transform.SetParent(null); // Detach from any parent GameObject.
            }

            if (instance == null)
            {
                instance = this as T;
                DontDestroyOnLoad(transform.gameObject); // Ensure this object persists across scene loads.
                enabled = true;
            }
            else
            {
                if (this != instance)
                {
                    Destroy(gameObject); // Destroy any duplicate singleton instance.
                }
            }
        }
    }
}
