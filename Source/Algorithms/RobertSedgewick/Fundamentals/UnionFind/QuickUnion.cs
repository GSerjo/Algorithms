using System;

namespace Algorithms.RobertSedgewick.Fundamentals.UnionFind
{
    /// <summary>
    ///     Elements as a tree.
    /// </summary>
    public sealed class QuickUnion
    {
        private readonly int[] _id;

        public QuickUnion(int count)
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
        ///     Connected only if element are belong to the same Tree (roots are the same).
        /// </summary>
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
            Count--;
            _id[idQ] = idP;
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
