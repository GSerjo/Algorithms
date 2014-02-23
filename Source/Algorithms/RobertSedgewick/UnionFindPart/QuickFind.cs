namespace Algorithms.RobertSedgewick.UnionFindPart
{
    public sealed class QuickFind : UnionFind
    {
        public QuickFind(int capacity) : base(capacity)
        {
        }

        protected override void UnionCore(int first, int second)
        {
            int firstIndex = GetIndex(first);
            int secondIndex = GetIndex(second);
            if (firstIndex == secondIndex)
            {
                return;
            }
            for (int i = 0; i < Indexes.Length; i++)
            {
                if (Indexes[i] == firstIndex)
                {
                    Indexes[i] = secondIndex;
                }
            }
        }
    }
}
