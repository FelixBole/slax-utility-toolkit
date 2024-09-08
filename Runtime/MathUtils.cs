using UnityEngine;

namespace Slax.Utils
{
    public static class MathUtils
    {
        /// <summary>
        /// Clamps a Vector3's x, y, and z components between the given min and max values.
        /// </summary>
        public static Vector3 ClampVector3(Vector3 value, Vector3 min, Vector3 max)
        {
            return new Vector3(
                Mathf.Clamp(value.x, min.x, max.x),
                Mathf.Clamp(value.y, min.y, max.y),
                Mathf.Clamp(value.z, min.z, max.z)
            );
        }

        /// <summary>
        /// Linear interpolation with easing (e.g., easing out for smooth transitions).
        /// </summary>
        public static float LerpEaseOut(float a, float b, float t)
        {
            t = 1f - Mathf.Cos(t * Mathf.PI * 0.5f); // Easing function
            return Mathf.Lerp(a, b, t);
        }
    }
}
