using System;

namespace Slax.Utils
{
    /// <summary>
    /// Represents an observable array that triggers events whenever the array is modified (e.g., items added, removed, swapped, or cleared).
    /// Provides an interface for implementing observable behavior on arrays.
    /// </summary>
    public interface IObservableArray<T>
    {
        /// <summary>
        /// Event triggered whenever any value in the array changes.
        /// This event fires when any modification to the array occurs, such as adding, removing, or swapping elements.
        /// </summary>
        event Action<T[]> AnyValueChanged;

        int Count { get; }
        T this[int index] { get; }

        void Swap(int index1, int index2);
        void Clear();
        bool TryAdd(T item);
        bool TryAddAt(int index, T item);
        bool TryRemove(T item);
        bool TryRemoveAt(int index);
    }
}
