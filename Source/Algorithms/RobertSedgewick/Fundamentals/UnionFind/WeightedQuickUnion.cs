namespace Algorithms.RobertSedgewick.Fundamentals.UnionFind
{
    public sealed class WeightedQuickUnion
    {
        private readonly int[] _ids;
        private readonly int[] _sizes;

        public WeightedQuickUnion(int length)
        {
            _ids = new int[length];
            _sizes = new int[length];

            for (var i = 0; i < length; i++)
            {
                _ids[i] = i;
                _sizes[i] = 1;
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

            if (_sizes[pRoot] < _sizes[qRoot])
            {
                _ids[pRoot] = qRoot;
                _sizes[qRoot] += _sizes[pRoot];
            }
            else
            {
                _ids[qRoot] = pRoot;
                _sizes[pRoot] += _sizes[qRoot];
            }

            Count--;
        }
    }
}
