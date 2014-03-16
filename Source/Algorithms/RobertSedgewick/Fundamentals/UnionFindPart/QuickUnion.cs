namespace Algorithms.RobertSedgewick.Fundamentals.UnionFindPart
{
    public sealed class QuickUnion : UnionFind
    {
        public QuickUnion(int capacity) : base(capacity)
        {
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

            if (firstRoot == secondRoot)
            {
                return;
            }
            Indexes[firstRoot] = secondRoot;
        }
    }
}
