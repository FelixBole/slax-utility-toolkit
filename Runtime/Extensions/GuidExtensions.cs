using System;

namespace Slax.Utils
{
    /// <summary>
    /// A static class that provides extension methods for converting between
    /// System.Guid and a custom SerializableGuid format. It allows for serialization
    /// of GUIDs by breaking them into four 32-bit parts, and converting them back.
    /// </summary>
    public static class GuidExtensions
    {
        /// <summary>
        /// Converts a System.Guid to a SerializableGuid, which breaks the 128-bit GUID
        /// into four 32-bit parts for serialization purposes.
        /// </summary>
        /// <param name="systemGuid">The System.Guid to be converted.</param>
        /// <returns>A SerializableGuid representing the System.Guid.</returns>
        public static SerializableGuid ToSerializableGuid(this Guid systemGuid)
        {
            byte[] bytes = systemGuid.ToByteArray();
            return new SerializableGuid(
                BitConverter.ToUInt32(bytes, 0),
                BitConverter.ToUInt32(bytes, 4),
                BitConverter.ToUInt32(bytes, 8),
                BitConverter.ToUInt32(bytes, 12)
            );
        }

        /// <summary>
        /// Converts a SerializableGuid back to a System.Guid by reassembling the
        /// 32-bit parts into a byte array and creating a new System.Guid from it.
        /// </summary>
        /// <param name="serializableGuid">The SerializableGuid to be converted.</param>
        /// <returns>A System.Guid representing the SerializableGuid.</returns>
        public static Guid ToSystemGuid(this SerializableGuid serializableGuid)
        {
            byte[] bytes = new byte[16];
            Buffer.BlockCopy(BitConverter.GetBytes(serializableGuid.Part1), 0, bytes, 0, 4);
            Buffer.BlockCopy(BitConverter.GetBytes(serializableGuid.Part2), 0, bytes, 4, 4);
            Buffer.BlockCopy(BitConverter.GetBytes(serializableGuid.Part3), 0, bytes, 8, 4);
            Buffer.BlockCopy(BitConverter.GetBytes(serializableGuid.Part4), 0, bytes, 12, 4);
            return new Guid(bytes);
        }
    }
}
