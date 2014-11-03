using System;

namespace Algorithms.RobertSedgewick.Fundamentals.DataStructures
{
    public sealed class StackArrayOf<T>
    {
        private T[] _array = new T[1];
        public int Count { get; private set; }

        public bool IsEmpty
        {
            get { return Count == 0; }
        }

        public T Pop()
        {
            if (IsEmpty)
            {
                throw new IndexOutOfRangeException();
            }
            T result = _array[--Count];
            if (Count > 0 && _array.Length / 4 == Count)
            {
                Resize(_array.Length / 2);
            }
            _array[Count] = default(T);
            return result;
        }

        public void Push(T value)
        {
            if (_array.Length == Count)
            {
                Resize(_array.Length * 2);
            }
            _array[Count++] = value;
        }

        private void Resize(int capacity)
        {
            var result = new T[capacity];
            for (int i = 0; i < Count; i++)
            {
                result[i] = _array[i];
            }
            _array = result;
        }
    }
}
