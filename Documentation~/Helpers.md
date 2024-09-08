# Observable Helpers Documentation

This document provides an overview of the observable helpers available in the `Slax.Utils` namespace. These classes allow arrays and lists to trigger events when they are modified, making them ideal for scenarios where UI or other systems need to react to data changes.

## `ObservableArray<T>` Class

| Method/Property Name | Description | When to Use |
| --- | --- | --- |
| `AnyValueChanged` | Event triggered whenever any value in the array changes. | Use this event to monitor when any modification (addition, removal, etc.) happens in the array. |
| `Count` | Returns the number of non-null elements in the array. | Use this to get the count of active (non-null) elements in the array. |
| `Length` | Returns the total length of the array (including null elements). | Use this to get the total number of slots in the array, regardless of null elements. |
| `this[int index]` | Accesses the element at the specified index. | Use this to retrieve an element by its index. |
| `Swap(int index1, int index2)` | Swaps two elements in the array at the specified indices. | Use this to switch the positions of two elements. |
| `Clear()` | Clears the array by resetting all elements to their default values. | Use this to remove all active elements and reset the array. |
| `TryAdd(T item)` | Attempts to add an item to the first available (null) slot in the array. | Use this when you want to add an item and automatically find the next available slot. |
| `TryAddAt(int index, T item)` | Attempts to add an item at a specific index if the slot is empty. | Use this to insert an item at a specific position in the array, if the slot is available (i.e., null). |
| `TryRemove(T item)` | Attempts to remove the first occurrence of the specified item from the array. | Use this to remove a specific item from the array. |
| `TryRemoveAt(int index)` | Removes the item at the specified index by setting it to its default value. | Use this to remove an element by its index. |

### Use Case:

Use `ObservableArray<T>` when you need an array-like data structure that triggers events whenever its elements are modified. This is especially useful for scenarios like inventory systems, where changes to the array should automatically trigger UI updates or other reactions.

---

## `ObservableList<T>` Class

| Method/Property Name | Description | When to Use |
| --- | --- | --- |
| `AnyValueChanged` | Event triggered whenever any value in the list changes. | Use this event to monitor when any modification (addition, removal, etc.) happens in the list. |
| `this[int index]` | Accesses the element at the specified index. | Use this to retrieve an element by its index. |
| `Add(T item)` | Adds an item to the list. | Use this to add an item to the end of the list. |
| `AddRange(IEnumerable<T> collection)` | Adds a range of items to the list. | Use this to add multiple items to the list at once. |
| `Clear()` | Clears the list by removing all elements. | Use this to remove all elements from the list. |
| `Remove(T item)` | Removes the first occurrence of the specified item from the list. | Use this to remove a specific item from the list. |
| `RemoveAt(int index)` | Removes the item at the specified index. | Use this to remove an element by its index. |

### Use Case:

Use `ObservableList<T>` when you need a list that triggers events whenever its elements are modified. This is useful for dynamic collections that may need to trigger updates when items are added or removed, such as a list of active tasks, player inventory, or UI elements.

---

## `IObservableArray<T>` Interface

| Method/Property Name | Description | When to Use |
| --- | --- | --- |
| `AnyValueChanged` | Event triggered whenever any value in the array changes. | Implement this event in your own observable array class to monitor array modifications. |
| `Count` | Returns the number of non-null elements in the array. | Implement this to get the count of active (non-null) elements in your array. |
| `this[int index]` | Accesses the element at the specified index. | Implement this to allow indexed access to elements in your array. |
| `Swap(int index1, int index2)` | Swaps two elements in the array at the specified indices. | Implement this to allow element swapping within your array. |
| `Clear()` | Clears the array by resetting all elements to their default values. | Implement this to clear your array. |
| `TryAdd(T item)` | Attempts to add an item to the first available (null) slot in the array. | Implement this to allow item addition with automatic slot finding. |
| `TryAddAt(int index, T item)` | Attempts to add an item at a specific index if the slot is empty. | Implement this to allow item addition at a specified index. |
| `TryRemove(T item)` | Attempts to remove the first occurrence of the specified item from the array. | Implement this to allow item removal based on the item’s value. |
| `TryRemoveAt(int index)` | Removes the item at the specified index by setting it to its default value. | Implement this to allow item removal at a specified index. |

---

## `IObservableList<T>` Interface

| Method/Property Name | Description | When to Use |
| --- | --- | --- |
| `AnyValueChanged` | Event triggered whenever any value in the list changes. | Implement this event in your own observable list class to monitor list modifications. |
| `this[int index]` | Accesses the element at the specified index. | Implement this to allow indexed access to elements in your list. |
| `Add(T item)` | Adds an item to the list. | Implement this to allow adding an item to your list. |
| `AddRange(IEnumerable<T> collection)` | Adds a range of items to the list. | Implement this to allow adding multiple items to your list. |
| `Clear()` | Clears the list by removing all elements. | Implement this to allow clearing all elements in your list. |
| `Remove(T item)` | Removes the first occurrence of the specified item from the list. | Implement this to allow item removal based on the item’s value. |
| `RemoveAt(int index)` | Removes the item at the specified index. | Implement this to allow removing an item by index. |

---

### Example Usage:

```csharp
// Example of an ObservableArray
ObservableArray<int> observableArray = new ObservableArray<int>(10);
observableArray.AnyValueChanged += (items) => Debug.Log("Array changed!");
observableArray.TryAdd(5);

// Example of an ObservableList
ObservableList<string> observableList = new ObservableList<string>();
observableList.AnyValueChanged += (list) => Debug.Log("List changed!");
observableList.Add("Item 1");
```
