using System;

namespace Algorithms.RobertSedgewick.Fundamentals.UnionFind
{
    public sealed class QuickUnion
    {
        private readonly int[] _data;

        public QuickUnion(int count)
        {
            _data = new int[count];

            for (int i = 0; i < count; i++)
            {
                _data[i] = i;
            }
            Count = count;
        }

        public int Count { get; private set; }

        public bool Connected(int p, int q)
        {
            return Find(p) == Find(q);
        }

        public void Union(int p, int q)
        {
            int pRoot = Find(p);
            int qRoot = Find(q);

            if (pRoot == qRoot)
            {
                return;
            }
            _data[pRoot] = qRoot;
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
