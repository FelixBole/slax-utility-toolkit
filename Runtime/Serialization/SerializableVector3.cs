using UnityEngine;

namespace Slax.Utils
{
    /// <summary>
    /// Represents a serializable version of Unity's Vector3 struct. 
    /// Useful in contexts where Unity's built-in Vector3 cannot be serialized, 
    /// such as with custom serialization systems or non-Unity formats.
    /// </summary>
    [System.Serializable]
    public struct SerializableVector3
    {
        public float x;
        public float y;
        public float z;

        /// <summary>
        /// Initializes a new instance of the SerializableVector3 struct with specified x, y, and z components.
        /// </summary>
        /// <param name="x">The x component of the vector.</param>
        /// <param name="y">The y component of the vector.</param>
        /// <param name="z">The z component of the vector.</param>
        public SerializableVector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        /// <summary>
        /// Returns a string representation of the SerializableVector3 in the format "[x, y, z]".
        /// </summary>
        /// <returns>A string representing the vector components.</returns>
        public override string ToString() => $"[{x}, {y}, {z}]";

        /// <summary>
        /// Implicit conversion from SerializableVector3 to Unity's Vector3.
        /// Allows for seamless assignment to Vector3 without explicit conversion.
        /// </summary>
        /// <param name="vector">The SerializableVector3 to convert.</param>
        public static implicit operator Vector3(SerializableVector3 vector)
        {
            return new Vector3(vector.x, vector.y, vector.z);
        }

        /// <summary>
        /// Implicit conversion from Unity's Vector3 to SerializableVector3.
        /// Allows for seamless assignment from Vector3 without explicit conversion.
        /// </summary>
        /// <param name="vector">The Vector3 to convert.</param>
        public static implicit operator SerializableVector3(Vector3 vector)
        {
            return new SerializableVector3(vector.x, vector.y, vector.z);
        }
    }
}
