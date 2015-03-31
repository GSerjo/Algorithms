using System;

namespace Algorithms.RobertSedgewick.Fundamentals.UnionFind
{
    public sealed class QuickFind
    {
        private readonly int[] _data;

        public QuickFind(int count)
        {
            _data = new int[count];
            Count = count;

            for (int i = 0; i < count; i++)
            {
                _data[i] = i;
            }
        }

        public int Count { get; private set; }

        public bool Connected(int p, int q)
        {
            return Find(p) == Find(q);
        }

        public void Union(int p, int q)
        {
            int pId = Find(p);
            int qId = Find(q);

            if (pId == qId)
            {
                return;
            }

            for (int i = 0; i < _data.Length; i++)
            {
                if (_data[i] == pId)
                {
                    _data[i] = qId;
                }
            }
            Count--;
        }

        private int Find(int p)
        {
            return _data[p];
        }
    }
}
