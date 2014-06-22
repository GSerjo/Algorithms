namespace Algorithms.RobertSedgewick.Fundamentals.UnionFindPart
{
    public abstract class UnionFind
    {
        protected UnionFind(int capacity)
        {
            Id = new int[capacity];
            for (int i = 0; i < capacity; i++)
            {
                Id[i] = i;
            }
        }

        public int[] Id {  get; protected set; }

        public bool Connected(int p, int q)
        {
            return GetIndex(p) == GetIndex(q);
        }

        public void Union(int p, int q)
        {
            UnionCore(p, q);
        }

        protected int GetIndex(int data)
        {
            return GetIndexCore(data);
        }

        protected abstract int GetIndexCore(int data);

        protected abstract void UnionCore(int p, int q);
    }
}
