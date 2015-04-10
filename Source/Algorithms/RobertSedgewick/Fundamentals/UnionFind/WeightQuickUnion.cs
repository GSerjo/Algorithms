using System;

namespace Algorithms.RobertSedgewick.Fundamentals.UnionFind
{
    public sealed class WeightQuickUnion
    {
        private readonly int[] _data;
        private readonly int[] _size;

        public WeightQuickUnion(int length)
        {
            _data = new int[length];
            _size = new int[length];

            for (int i = 0; i < length; i++)
            {
                _data[i] = i;
                _size[i] = 1;
            }
            Count = length;
        }

        public int Count { get; private set; }

        public bool Connected(int p, int q)
        {
            return Find(p) == Find(q);
        }

        public void Union(int p, int q)
        {
            var pRoot = Find(p);
            var qRoot = Find(q);
            if (pRoot == qRoot)
            {
                return;
            }

            if (_size[pRoot] > _size[qRoot])
            {
                _data[qRoot] = pRoot;
                _size[pRoot] += _size[qRoot];
            }
            else
            {
                _data[pRoot] = qRoot;
                _size[qRoot] += pRoot;
            }
            Count--;
        }

        private int Find(int p)
        {
            while (p != _data[p])
            {
                p = _data[p];
            }
            return p;
        }
    }
}
