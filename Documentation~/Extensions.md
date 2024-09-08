# Extensions.md

This document covers all extension methods provided in the `Slax.Utils` namespace.

## GuidExtensions Class

| Method Name | Description | When to Use |
| --- | --- | --- |
| `ToSerializableGuid()` | Converts a `System.Guid` to a `SerializableGuid`. | Use this when you need to serialize a `Guid` into a format that Unity can serialize, useful for persistence or saving GUIDs in a Unity-friendly format. |
| `ToSystemGuid()` | Converts a `SerializableGuid` back to a `System.Guid`. | Use this when you need to convert a serialized GUID back into a `System.Guid` for normal use, such as database lookups or identification. |

## Example Usage

```csharp
// Convert System.Guid to SerializableGuid
Guid systemGuid = Guid.NewGuid();
SerializableGuid serializableGuid = systemGuid.ToSerializableGuid();

// Convert SerializableGuid back to System.Guid
Guid restoredGuid = serializableGuid.ToSystemGuid();
```
