namespace Algorithms.RobertSedgewick.Fundamentals.UnionFind
{
    public sealed class QuickUnion
    {
        private readonly int[] _ids;

        public QuickUnion(int length)
        {
            _ids = new int[length];
            for (var i = 0; i < length; i++)
            {
                _ids[i] = i;
            }
            Count = length;
        }

        public int Count { get; private set; }

        public bool Connected(int p, int q)
        {
            return Find(p) == Find(q);
        }

        public int Find(int p)
        {
            while (p != _ids[p])
            {
                p = _ids[p];
            }
            return p;
        }

        public void Union(int p, int q)
        {
            int pRoot = Find(p);
            int qRoot = Find(q);

            if (pRoot == qRoot)
            {
                return;
            }
            _ids[pRoot] = qRoot;
            Count--;
        }
    }
}
