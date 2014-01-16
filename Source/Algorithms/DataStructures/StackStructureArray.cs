using System;
using System.Text;

namespace Algorithms.DataStructures
{
    public sealed class StackStructureArray<T>
    {
        private T[] _data = new T[0];
        private int _size;

        public T Pop()
        {
            if (_size == 0)
            {
                throw new IndexOutOfRangeException();
            }
            _size--;
            T result = _data[_size];
            _data[_size] = default(T);
            return result;
        }

        public StackStructureArray<T> Push(T value)
        {
            if (_size == _data.Length)
            {
                int newSize = _size == 0 ? 4 : _size*2;
                var tempArray = new T[newSize];
                _data.CopyTo(tempArray, 0);
                _data = tempArray;
            }
            _data[_size] = value;
            _size++;
            return this;
        }

        public override string ToString()
        {
            var builder = new StringBuilder("{");
            for (int i = _size - 1; i >= 0; i--)
            {
                builder.AppendFormat("{0};", _data[i]);
            }
            builder.Append("}");
            return builder.ToString();
        }
    }
}
