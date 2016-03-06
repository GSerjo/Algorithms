namespace Algorithms.RobertSedgewick.Fundamentals.UnionFind
{
    public sealed class QuickFind
    {
        private readonly int[] _ids;

        public QuickFind(int length)
        {
            _ids = new int[length];
            for (var i = 0; i < length; i++)
            {
                _ids[i] = i;
            }
            Count = length;
        }

        public int Count { get; private set; }

        public void Union(int p, int q)
        {
            int idP = Find(p);
            int idQ = Find(q);

            if (idP == idQ)
            {
                return;
            }
            for (var i = 0; i < _ids.Length; i++)
            {
                if (_ids[i] == idP)
                {
                    _ids[i] = idQ;
                }
            }
            Count--;
        }

        public bool Connected(int p, int q)
        {
            return Find(p) == Find(q);
        }

        public int Find(int p)
        {
            return _ids[p];
        }
    }
}
