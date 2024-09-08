using System;
using System.Collections.Generic;

namespace Slax.Utils
{
    /// <summary>
    /// Implementation of an observable list that triggers events when the list is modified.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    [Serializable]
    public class ObservableList<T> : List<T>, IObservableList<T>
    {
        public event Action<List<T>> AnyValueChanged = delegate { };

        public ObservableList() : base() { }

        public ObservableList(int capacity) : base(capacity) { }

        public ObservableList(IEnumerable<T> collection) : base(collection)
        {
            Invoke();
        }

        private void Invoke() => AnyValueChanged.Invoke(this);

        public new void Add(T item)
        {
            base.Add(item);
            Invoke();
        }

        public new void AddRange(IEnumerable<T> collection)
        {
            base.AddRange(collection);
            Invoke();
        }

        public new void Clear()
        {
            base.Clear();
            Invoke();
        }

        public new bool Remove(T item)
        {
            var result = base.Remove(item);
            Invoke();
            return result;
        }

        public new void RemoveAt(int index)
        {
            base.RemoveAt(index);
            Invoke();
        }
    }
}
