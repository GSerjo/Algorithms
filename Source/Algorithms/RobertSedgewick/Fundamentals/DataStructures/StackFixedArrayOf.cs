using System;

namespace Algorithms.RobertSedgewick.Fundamentals.DataStructures
{
    public sealed class StackFixedArrayOf<T>
    {
        private readonly T[] _array;

        public StackFixedArrayOf(int capacity)
        {
            _array = new T[capacity];
        }

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
            _array[Count] = default(T);
            return result;
        }

        public void Push(T value)
        {
            if (Count == _array.Length)
            {
                throw new IndexOutOfRangeException();
            }
            _array[Count++] = value;
        }
    }
}
