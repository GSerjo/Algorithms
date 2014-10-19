using System;

namespace Algorithms.RobertSedgewick.Fundamentals.UnionFind
{
    public sealed class WeightedQuickUnion
    {
        private readonly int[] _id;
        private readonly int[] _size;

        public WeightedQuickUnion(int count)
        {
            _id = new int[count];
            _size = new int[count];

            for (int i = 0; i < count; i++)
            {
                _id[i] = i;
                _size[i] = 1;
            }

            Count = count;
        }

        public int Count { get; private set; }

        public bool Connected(int p, int q)
        {
            return Root(p) == Root(q);
        }

        public void Union(int p, int q)
        {
            int idP = Root(p);
            int idQ = Root(q);

            if (idP == idQ)
            {
                return;
            }

            if (_size[idP] > _size[idQ])
            {
                _id[idQ] = idP;
                _size[idP] += _size[idQ];
            }
            else
            {
                _id[idP] = idQ;
                _size[idQ] += _size[idP];
            }
            Count--;
        }

        private int Root(int p)
        {
            while (p != _id[p])
            {
                p = _id[p];
            }
            return p;
        }
    }
}
