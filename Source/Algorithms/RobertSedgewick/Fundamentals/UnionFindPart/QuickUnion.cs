namespace Algorithms.RobertSedgewick.Fundamentals.UnionFindPart
{
    public sealed class QuickUnion : UnionFind
    {
        public QuickUnion(int capacity) : base(capacity)
        {
        }

        protected override int GetIndexCore(int data)
        {
            while (data != Id[data])
            {
                data = Id[data];
            }
            return data;
        }

        protected override void UnionCore(int p, int q)
        {
            int firstRoot = GetIndex(p);
            int secondRoot = GetIndex(q);

            if (firstRoot == secondRoot)
            {
                return;
            }
            Id[firstRoot] = secondRoot;
        }
    }
}
