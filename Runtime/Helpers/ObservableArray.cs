using System;
using System.Collections.Generic;
using System.Linq;

namespace Slax.Utils
{
    /// <summary>
    /// Represents an observable array that triggers events whenever the array is modified (e.g., items added, removed, swapped, or cleared).
    /// Useful for scenarios where changes to the array need to be monitored or responded to, such as UI updates or persistence systems.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    [Serializable]
    public class ObservableArray<T> : IObservableArray<T>
    {
        public T[] items;

        /// <summary>
        /// Event triggered whenever any value in the array changes.
        /// </summary>
        public event Action<T[]> AnyValueChanged = delegate { };

        /// <summary>
        /// Gets the number of non-null elements in the array.
        /// </summary>
        public int Count => items.Count(i => i != null);

        /// <summary>
        /// Gets the total length of the array.
        /// </summary>
        public int Length => items.Length;

        /// <summary>
        /// Accesses an element at the specified index.
        /// </summary>
        /// <param name="index">The index of the element to access.</param>
        public T this[int index] => items[index];

        /// <summary>
        /// Initializes a new instance of the <see cref="ObservableArray{T}"/> class with a specified size or initial list of elements.
        /// </summary>
        /// <param name="size">The size of the array. Default is 20.</param>
        /// <param name="initialList">An optional list of initial elements.</param>
        public ObservableArray(int size = 20, IList<T> initialList = null)
        {
            items = new T[size];
            if (initialList != null)
            {
                initialList.Take(size).ToArray().CopyTo(items, 0);
                Invoke();
            }
        }

        /// <summary>
        /// Invokes the <see cref="AnyValueChanged"/> event.
        /// </summary>
        void Invoke() => AnyValueChanged.Invoke(items);

        /// <summary>
        /// Swaps two elements in the array at the specified indices.
        /// </summary>
        /// <param name="index1">The index of the first element.</param>
        /// <param name="index2">The index of the second element.</param>
        public void Swap(int index1, int index2)
        {
            (items[index1], items[index2]) = (items[index2], items[index1]);
            Invoke();
        }

        /// <summary>
        /// Clears the array by resetting all elements to their default values.
        /// </summary>
        public void Clear()
        {
            items = new T[items.Length];
            Invoke();
        }

        /// <summary>
        /// Attempts to add an item to the first available (null) slot in the array.
        /// </summary>
        /// <param name="item">The item to add.</param>
        /// <returns>True if the item was added, otherwise false.</returns>
        public bool TryAdd(T item)
        {
            for (var i = 0; i < items.Length; i++)
            {
                if (TryAddAt(i, item)) return true;
            }
            return false;
        }

        /// <summary>
        /// Attempts to add an item at a specific index if the slot is empty.
        /// </summary>
        /// <param name="index">The index at which to add the item.</param>
        /// <param name="item">The item to add.</param>
        /// <returns>True if the item was added, otherwise false.</returns>
        public bool TryAddAt(int index, T item)
        {
            if (index < 0 || index >= items.Length) return false;
            if (items[index] != null) return false;

            items[index] = item;
            Invoke();
            return true;
        }

        /// <summary>
        /// Attempts to remove the first occurrence of the specified item from the array.
        /// </summary>
        /// <param name="item">The item to remove.</param>
        /// <returns>True if the item was removed, otherwise false.</returns>
        public bool TryRemove(T item)
        {
            for (var i = 0; i < items.Length; i++)
            {
                if (EqualityComparer<T>.Default.Equals(items[i], item) && TryRemoveAt(i)) return true;
            }
            return false;
        }

        /// <summary>
        /// Removes the item at the specified index by setting it to its default value.
        /// </summary>
        /// <param name="index">The index of the item to remove.</param>
        /// <returns>True if the item was removed, otherwise false.</returns>
        public bool TryRemoveAt(int index)
        {
            if (index < 0 || index >= items.Length) return false;
            if (items[index] == null) return false;

            items[index] = default;
            Invoke();
            return true;
        }
    }
}
