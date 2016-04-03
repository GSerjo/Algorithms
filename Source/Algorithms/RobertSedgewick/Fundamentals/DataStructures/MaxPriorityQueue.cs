using System;

namespace Algorithms.RobertSedgewick.Fundamentals.DataStructures
{
    public sealed class MaxPriorityQueue<T>
        where T : IComparable
    {
        private readonly T[] _data;

        public MaxPriorityQueue(int length)
        {
            _data = new T[length + 1];
        }

        public int Count { get; private set; }
        public bool IsEmpty => Count == 0;

        public void Enqueue(T value)
        {
            _data[++Count] = value;
            Swim(Count);
        }

        public T Dequeue()
        {
            if (IsEmpty)
            {
                throw new IndexOutOfRangeException();
            }
            T result = _data[1];
            Swap(1, Count--);
            _data[Count + 1] = default(T);
            Sink(1);
            return result;
        }

        private void Swim(int k)
        {
            while (k > 1 && Less(k/2, k))
            {
                Swap(k / 2, k);
                k = k / 2;
            }
        }

        private void Sink(int k)
        {
            while (k <= Count)
            {
                int i = 2 * k;
                if (k < Count && Less(i, i + 1))
                {
                    i = i + 1;
                }
                if (!Less(k, i))
                {
                    break;
                }
                Swap(k, i);
                k = i;
            }
        }

        private void Swap(int i, int j)
        {
            T dummy = _data[i];
            _data[i] = _data[j];
            _data[j] = dummy;
        }

        private bool Less(int i, int j)
        {
            return _data[i].CompareTo(_data[j]) < 0;
        }
    }
}
