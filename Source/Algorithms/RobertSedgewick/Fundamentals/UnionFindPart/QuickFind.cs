namespace Algorithms.RobertSedgewick.Fundamentals.UnionFindPart
{
    public sealed class QuickFind : UnionFind
    {
        public QuickFind(int capacity) : base(capacity)
        {
        }

        protected override int GetIndexCore(int data)
        {
            return Id[data];
        }

        protected override void UnionCore(int p, int q)
        {
            int pId = GetIndex(p);
            int qId = GetIndex(q);
            if (pId == qId)
            {
                return;
            }
            for (int i = 0; i < Id.Length; i++)
            {
                if (Id[i] == pId)
                {
                    Id[i] = qId;
                }
            }
        }
    }
}
