using System;

namespace Algorithms.RobertSedgewick.Sorting
{
    public sealed class PriorityQueue<T>
        where T : IComparable
    {
        private readonly T[] _data;
        private int _capacity;

        public PriorityQueue(int length)
        {
            _data = new T[++length];
        }

        public bool IsEmpty
        {
            get { return _capacity == 0; }
        }

        public void Insert(T value)
        {
            _data[++_capacity] = value;
            Swim(_capacity);
        }

        private void Exchange(int left, int right)
        {
            T key = _data[left];
            _data[left] = _data[right];
            _data[right] = key;
        }

        private bool Less(int left, int right)
        {
            return _data[left].CompareTo(_data[right]) < 0;
        }

        private void Swim(int index)
        {
            while (index > 1 && Less(index / 2, index))
            {
                Exchange(index / 2, index);
                index = index / 2;
            }
        }
    }
}
