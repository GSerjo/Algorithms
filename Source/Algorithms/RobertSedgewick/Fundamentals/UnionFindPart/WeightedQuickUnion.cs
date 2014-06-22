using System;

namespace Algorithms.RobertSedgewick.Fundamentals.UnionFindPart
{
    public sealed class WeightedQuickUnion : UnionFind
    {
        private readonly int[] _sizes;

        public WeightedQuickUnion(int capacity) : base(capacity)
        {
            _sizes = new int[capacity];
            for (int i = 0; i < capacity; i++)
            {
                _sizes[i] = 1;
            }
        }

        public int Depth(int p)
        {
            int result = 0;
            while (p != Id[p])
            {
                p = Id[p];
                result++;
            }
            return result;
        }

        public void SetId(int[] value)
        {
            if (value.Length != Id.Length)
            {
                throw new InvalidOperationException();
            }
            Id = value;
        }

        protected override int GetIndexCore(int data)
        {
            while (data != Id[data])
            {
                data = Id[data];
            }
            return data;
        }

        protected override void UnionCore(int p, int q)
        {
            int firstRoot = GetIndex(p);
            int secondRoot = GetIndex(q);
            if (_sizes[firstRoot] < _sizes[secondRoot])
            {
                Id[firstRoot] = secondRoot;
                _sizes[secondRoot] += _sizes[firstRoot];
            }
            else
            {
                Id[secondRoot] = firstRoot;
                _sizes[firstRoot] += _sizes[secondRoot];
            }
        }
    }
}
