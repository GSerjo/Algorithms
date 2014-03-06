using System;

namespace Algorithms.RobertSedgewick.DataStructures
{
    public sealed class ArrayStack<TItem>
    {
        private int _capacity;
        private TItem[] _data = new TItem[4];

        public TItem Pop()
        {
            TItem result = _data[--_capacity];
            _data[_capacity] = default(TItem);
            if (_capacity > 0 && _capacity == _data.Length/4)
            {
                Resize(_data.Length/2);
            }
            return result;
        }

        public void Push(TItem value)
        {
            if (_capacity == _data.Length)
            {
                Resize(_data.Length*2);
            }
            _data[_capacity++] = value;
        }

        private void Resize(int length)
        {
            var newArray = new TItem[length];
            Array.Copy(_data, newArray, _data.Length);
            _data = newArray;
        }
    }
}
