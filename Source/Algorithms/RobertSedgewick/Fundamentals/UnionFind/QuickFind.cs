using System;

namespace Algorithms.RobertSedgewick.Fundamentals.UnionFind
{
    /// <summary>
    ///     Element as a component
    /// </summary>
    public sealed class QuickFind
    {
        private readonly int[] _id;

        public QuickFind(int count)
        {
            _id = new int[count];
            for (int i = 0; i < count; i++)
            {
                _id[i] = i;
            }
            Count = count;
        }

        public int Count { get; private set; }

        /// <summary>
        ///     Connected only if element are belong to the same component.
        /// </summary>
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

            for (int i = 0; i < _id.Length; i++)
            {
                if (_id[i] == pId)
                {
                    _id[i] = qId;
                }
            }
            Count--;
        }

        private int Find(int p)
        {
            return _id[p];
        }
    }
}
