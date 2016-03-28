using System;

namespace Algorithms.RobertSedgewick.Fundamentals.DataStructures
{
    public sealed class StackArrayOf<T>
    {
        private T[] _data = new T[1];
        public int Count { get; private set; }
        public bool IsEmpty => Count == 0;

        public T Pop()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException();
            }
            T result = _data[--Count];
            return result;
        }

        public void Push(T value)
        {
            if (_data.Length == Count)
            {
                Resize(_data.Length * 2);
            }
            _data[Count++] = value;
        }

        private void Resize(int lenght)
        {
            var result = new T[lenght];

            for (var i = 0; i < _data.Length; i++)
            {
                result[i] = _data[i];
            }
            _data = result;
        }
    }
}
