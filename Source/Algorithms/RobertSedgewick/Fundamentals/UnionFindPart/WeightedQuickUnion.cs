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

        protected override int GetIndexCore(int data)
        {
            while (data != Indexes[data])
            {
                data = Indexes[data];
            }
            return data;
        }

        protected override void UnionCore(int first, int second)
        {
            int firstRoot = GetIndex(first);
            int secondRoot = GetIndex(second);
            if (_sizes[firstRoot] < _sizes[secondRoot])
            {
                Indexes[firstRoot] = secondRoot;
                _sizes[secondRoot] += _sizes[firstRoot];
            }
            else
            {
                Indexes[secondRoot] = firstRoot;
                _sizes[firstRoot] += _sizes[secondRoot];
            }
        }
    }
}
