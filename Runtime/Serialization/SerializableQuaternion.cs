using UnityEngine;
using System;

namespace Slax.Utils
{
    /// <summary>
    /// Represents a serializable version of Unity's Quaternion struct.
    /// Useful in contexts where Unity's built-in Quaternion cannot be serialized,
    /// such as with custom serialization systems or non-Unity formats.
    /// </summary>
    [Serializable]
    public struct SerializableQuaternion
    {
        public float x;
        public float y;
        public float z;
        public float w;

        /// <summary>
        /// Initializes a new instance of the SerializableQuaternion struct with the specified x, y, z, and w components.
        /// </summary>
        /// <param name="x">The x component of the quaternion.</param>
        /// <param name="y">The y component of the quaternion.</param>
        /// <param name="z">The z component of the quaternion.</param>
        /// <param name="w">The w component of the quaternion.</param>
        public SerializableQuaternion(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        /// <summary>
        /// Returns a string representation of the SerializableQuaternion in the format "[x, y, z, w]".
        /// </summary>
        /// <returns>A string representing the quaternion components.</returns>
        public override string ToString() => $"[{x}, {y}, {z}, {w}]";

        /// <summary>
        /// Implicit conversion from SerializableQuaternion to Unity's Quaternion.
        /// Allows for seamless assignment to Quaternion without explicit conversion.
        /// </summary>
        /// <param name="quaternion">The SerializableQuaternion to convert.</param>
        public static implicit operator Quaternion(SerializableQuaternion quaternion)
        {
            return new Quaternion(quaternion.x, quaternion.y, quaternion.z, quaternion.w);
        }

        /// <summary>
        /// Implicit conversion from Unity's Quaternion to SerializableQuaternion.
        /// Allows for seamless assignment from Quaternion without explicit conversion.
        /// </summary>
        /// <param name="quaternion">The Quaternion to convert.</param>
        public static implicit operator SerializableQuaternion(Quaternion quaternion)
        {
            return new SerializableQuaternion(quaternion.x, quaternion.y, quaternion.z, quaternion.w);
        }
    }
}
