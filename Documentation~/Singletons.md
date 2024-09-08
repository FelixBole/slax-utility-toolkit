# Singleton Classes Documentation

This document provides an overview of the singleton classes available in the `Slax.Utils` namespace. These classes help ensure that only one instance of a component or object exists in the game, providing different behaviors depending on the use case.

## `PersistentSingleton<T>` Class

| Method/Property Name | Description | When to Use |
| --- | --- | --- |
| `UnparentOnAwake` | If true, the singleton will detach itself from its parent GameObject on awake. | Use this when the singleton should be independent of any hierarchy it might be created under. |
| `HasInstance` | Returns true if an instance of the singleton already exists. | Use this to check whether an instance of the singleton is currently active in the scene. |
| `Current` | Provides the current instance of the singleton. | Use this to access the singleton without invoking instance creation. |
| `Instance` | Gets the singleton instance. If it doesn't exist, creates a new one. | Use this to retrieve the singleton, creating it if necessary. |
| `Awake()` | Called when the script is loaded. Initializes the singleton and unparents if needed. | This is automatically invoked by Unity when the GameObject is loaded. |
| `InitializeSingleton()` | Initializes the singleton. Ensures it persists across scenes and destroys duplicates. | This is automatically called in `Awake()`, handling the setup for the singleton pattern. |

### Use Case:

Use `PersistentSingleton<T>` when you need a singleton that persists across scene loads and you want to ensure there is only one instance of that object. It is especially useful for managers or systems that need to stay active through scene transitions (e.g., `GameManager`, `AudioManager`).

---

## `Singleton<T>` Class

| Method/Property Name | Description | When to Use |
| --- | --- | --- |
| `Instance` | Gets or sets the static instance of the singleton. | Use this to access the singleton instance. |
| `Awake()` | Ensures only one instance exists by destroying any duplicates. | Use this to enforce strict singleton behavior where duplicate instances are destroyed. |

### Use Case:

Use `Singleton<T>` when you want to ensure that only one instance of an object exists, and you want to destroy any newly created duplicates. This is useful for non-persistent objects where having duplicates can cause issues (e.g., UI managers, input managers).

---

## `StaticInstance<T>` Class

| Method/Property Name | Description | When to Use |
| --- | --- | --- |
| `Instance` | Gets or sets the static instance of the class. | Use this to access or override the static instance of the class. |
| `Awake()` | Sets the instance to the current object. | Use this to initialize the static instance without destroying any duplicates. |
| `OnApplicationQuit()` | Resets the instance and destroys the GameObject on application quit. | Use this to clean up the instance when the application is closed. |

### Use Case:

Use `StaticInstance<T>` when you want to allow the singleton instance to be replaced by a new instance, such as when resetting the state of the object. This is useful in situations where an object’s state might change and a new instance is needed to reflect the updated state (e.g., level managers or configuration managers).

---

## General Tips:

- **`PersistentSingleton<T>`**: Use this when the singleton must survive scene changes (e.g., core systems like `GameManager` or `AudioManager`).
- **`Singleton<T>`**: Use this for strict singleton behavior where you want to destroy any duplicate instances immediately (e.g., game systems that should only ever have one instance at a time).
- **`StaticInstance<T>`**: Use this when you want a singleton-like pattern but need the flexibility to override the instance (e.g., for resetting states or switching configurations).

---

### Example Usage:

```csharp
// Example of a PersistentSingleton
public class GameManager : PersistentSingleton<GameManager>
{
    // Custom logic for the GameManager
}

// Example of a Singleton
public class UIManager : Singleton<UIManager>
{
    // Custom logic for the UIManager
}

// Example of a StaticInstance
public class LevelManager : StaticInstance<LevelManager>
{
    // Custom logic for the LevelManager
}
```
