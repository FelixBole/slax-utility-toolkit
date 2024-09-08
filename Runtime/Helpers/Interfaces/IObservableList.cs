using System;
using System.Collections.Generic;

namespace Slax.Utils
{
    /// <summary>
    /// Represents an observable list that triggers events when modified.
    /// </summary>
    public interface IObservableList<T>
    {
        /// <summary>
        /// Event triggered whenever any value in the list changes.
        /// This event fires when any modification to the list occurs, such as adding, removing elements, or clearing the list.
        /// </summary>
        event Action<List<T>> AnyValueChanged;

        int Count { get; }
        T this[int index] { get; }

        void Add(T item);
        void AddRange(IEnumerable<T> collection);
        bool Remove(T item);
        void RemoveAt(int index);
        void Clear();
    }
}
