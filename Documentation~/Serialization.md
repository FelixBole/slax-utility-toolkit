# Serialization

This document provides an overview of all the serializable structs available in the `Slax.Utils` namespace. These structs enable Unity-friendly serialization of commonly used types such as GUIDs, Quaternions, and Vector3s.

## SerializableGuid Struct

| Method/Property Name | Description | When to Use |
| --- | --- | --- |
| `Empty` | Returns a `SerializableGuid` with all parts set to zero. | Use this when you need to represent a blank or uninitialized `SerializableGuid`. |
| `NewGuid()` | Generates a new `SerializableGuid` using a newly created `System.Guid`. | Use this when you need to create a new globally unique identifier (GUID) that is serializable in Unity. |
| `FromHexString()` | Creates a `SerializableGuid` from a 32-character hexadecimal string. | Use this when you have a hex string representation of a GUID and need to convert it into a `SerializableGuid`. |
| `ToHexString()` | Converts the `SerializableGuid` to its hexadecimal string representation. | Use this when you need to get a string representation of the GUID for storage or display purposes. |
| `ToGuid()` | Converts the `SerializableGuid` back to a `System.Guid`. | Use this when you need to convert a `SerializableGuid` into a standard `System.Guid`. |

## SerializableQuaternion Struct

| Method/Property Name | Description | When to Use |
| --- | --- | --- |
| `SerializableQuaternion(float x, float y, float z, float w)` | Initializes a `SerializableQuaternion` with the specified components. | Use this when creating a quaternion from specific values. |
| `ToString()` | Returns a string representation of the `SerializableQuaternion` in the format "[x, y, z, w]". | Use this for debugging or displaying quaternion values as a string. |
| Implicit conversion to `Quaternion` | Converts a `SerializableQuaternion` to a Unity `Quaternion`. | Use this when you want to easily convert from `SerializableQuaternion` to Unity’s `Quaternion`. |
| Implicit conversion from `Quaternion` | Converts a Unity `Quaternion` to a `SerializableQuaternion`. | Use this when you want to easily convert from Unity’s `Quaternion` to `SerializableQuaternion`. |

## SerializableVector3 Struct

| Method/Property Name | Description | When to Use |
| --- | --- | --- |
| `SerializableVector3(float x, float y, float z)` | Initializes a `SerializableVector3` with the specified components. | Use this when creating a vector from specific values. |
| `ToString()` | Returns a string representation of the `SerializableVector3` in the format "[x, y, z]". | Use this for debugging or displaying vector values as a string. |
| Implicit conversion to `Vector3` | Converts a `SerializableVector3` to a Unity `Vector3`. | Use this when you want to easily convert from `SerializableVector3` to Unity’s `Vector3`. |
| Implicit conversion from `Vector3` | Converts a Unity `Vector3` to a `SerializableVector3`. | Use this when you want to easily convert from Unity’s `Vector3` to `SerializableVector3`. |

## Example Usage

```csharp
// Create a SerializableGuid
SerializableGuid guid = SerializableGuid.NewGuid();
string hexString = guid.ToHexString();

// Create a SerializableQuaternion from a Unity Quaternion
Quaternion unityQuat = Quaternion.identity;
SerializableQuaternion serialQuat = unityQuat;

// Create a SerializableVector3 from a Unity Vector3
Vector3 unityVec = new Vector3(1, 2, 3);
SerializableVector3 serialVec = unityVec;
```
