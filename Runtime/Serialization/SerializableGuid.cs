using UnityEngine;

namespace Slax.Utils
{
    /// <summary>
    /// Represents a globally unique identifier (GUID) that is serializable with Unity 
    /// and can be used in game scripts for fast ID checks, especially useful for persistence.
    /// </summary>
    [System.Serializable]
    public struct SerializableGuid : System.IEquatable<SerializableGuid>
    {
        [SerializeField, HideInInspector] public uint Part1;
        [SerializeField, HideInInspector] public uint Part2;
        [SerializeField, HideInInspector] public uint Part3;
        [SerializeField, HideInInspector] public uint Part4;

        /// <summary>
        /// Returns an empty SerializableGuid with all parts set to 0.
        /// </summary>
        public static SerializableGuid Empty => new(0, 0, 0, 0);

        /// <summary>
        /// Creates a SerializableGuid from four 32-bit unsigned integers.
        /// </summary>
        public SerializableGuid(uint val1, uint val2, uint val3, uint val4)
        {
            Part1 = val1;
            Part2 = val2;
            Part3 = val3;
            Part4 = val4;
        }

        /// <summary>
        /// Creates a SerializableGuid from a System.Guid by converting it to four parts.
        /// </summary>
        public SerializableGuid(System.Guid guid)
        {
            byte[] bytes = guid.ToByteArray();
            Part1 = System.BitConverter.ToUInt32(bytes, 0);
            Part2 = System.BitConverter.ToUInt32(bytes, 4);
            Part3 = System.BitConverter.ToUInt32(bytes, 8);
            Part4 = System.BitConverter.ToUInt32(bytes, 12);
        }

        /// <summary>
        /// Generates a new SerializableGuid using a newly created System.Guid.
        /// </summary>
        public static SerializableGuid NewGuid() => System.Guid.NewGuid().ToSerializableGuid();

        /// <summary>
        /// Creates a SerializableGuid from a 32-character hexadecimal string.
        /// </summary>
        /// <param name="hexString">The hexadecimal string representing the GUID (32 characters).</param>
        /// <returns>A SerializableGuid parsed from the hex string or an empty SerializableGuid if invalid.</returns>
        public static SerializableGuid FromHexString(string hexString)
        {
            if (hexString.Length != 32)
            {
                return Empty;
            }

            return new SerializableGuid
            (
                System.Convert.ToUInt32(hexString.Substring(0, 8), 16),
                System.Convert.ToUInt32(hexString.Substring(8, 8), 16),
                System.Convert.ToUInt32(hexString.Substring(16, 8), 16),
                System.Convert.ToUInt32(hexString.Substring(24, 8), 16)
            );
        }

        /// <summary>
        /// Converts the SerializableGuid to its hexadecimal string representation.
        /// </summary>
        /// <returns>A 32-character string representing the SerializableGuid.</returns>
        public string ToHexString()
        {
            return $"{Part1:X8}{Part2:X8}{Part3:X8}{Part4:X8}";
        }

        /// <summary>
        /// Converts the SerializableGuid back to a System.Guid.
        /// </summary>
        /// <returns>The System.Guid representation of this SerializableGuid.</returns>
        public System.Guid ToGuid()
        {
            var bytes = new byte[16];
            System.BitConverter.GetBytes(Part1).CopyTo(bytes, 0);
            System.BitConverter.GetBytes(Part2).CopyTo(bytes, 4);
            System.BitConverter.GetBytes(Part3).CopyTo(bytes, 8);
            System.BitConverter.GetBytes(Part4).CopyTo(bytes, 12);
            return new System.Guid(bytes);
        }

        /// <summary>
        /// Implicit conversion from SerializableGuid to System.Guid.
        /// </summary>
        public static implicit operator System.Guid(SerializableGuid serializableGuid) => serializableGuid.ToGuid();

        /// <summary>
        /// Implicit conversion from System.Guid to SerializableGuid.
        /// </summary>
        public static implicit operator SerializableGuid(System.Guid guid) => new SerializableGuid(guid);

        /// <summary>
        /// Checks if the current SerializableGuid is equal to another object.
        /// </summary>
        /// <param name="obj">The object to compare to.</param>
        /// <returns>True if the objects are equal, otherwise false.</returns>
        public override bool Equals(object obj)
        {
            return obj is SerializableGuid guid && this.Equals(guid);
        }

        /// <summary>
        /// Checks if the current SerializableGuid is equal to another SerializableGuid.
        /// </summary>
        /// <param name="other">The other SerializableGuid to compare to.</param>
        /// <returns>True if the GUIDs are equal, otherwise false.</returns>
        public bool Equals(SerializableGuid other)
        {
            return Part1 == other.Part1 && Part2 == other.Part2 && Part3 == other.Part3 && Part4 == other.Part4;
        }

        /// <summary>
        /// Returns a hash code for the SerializableGuid.
        /// </summary>
        /// <returns>An integer hash code.</returns>
        public override int GetHashCode()
        {
            return System.HashCode.Combine(Part1, Part2, Part3, Part4);
        }

        /// <summary>
        /// Equality operator to compare two SerializableGuid instances.
        /// </summary>
        public static bool operator ==(SerializableGuid left, SerializableGuid right) => left.Equals(right);

        /// <summary>
        /// Inequality operator to compare two SerializableGuid instances.
        /// </summary>
        public static bool operator !=(SerializableGuid left, SerializableGuid right) => !(left == right);
    }
}
