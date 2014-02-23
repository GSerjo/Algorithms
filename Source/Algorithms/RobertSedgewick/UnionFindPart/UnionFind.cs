namespace Algorithms.RobertSedgewick.UnionFindPart
{
    public abstract class UnionFind
    {
        protected UnionFind(int capacity)
        {
            Indexes = new int[capacity];
            for (int i = 0; i < capacity; i++)
            {
                Indexes[i] = i;
            }
        }

        public int[] Indexes { get; private set; }

        public bool Connected(int first, int second)
        {
            return Indexes[first] == Indexes[second];
        }

        public void Union(int first, int second)
        {
            UnionCore(first, second);
        }

        protected int GetIndex(int data)
        {
            return Indexes[data];
        }

        protected abstract void UnionCore(int first, int second);
    }
}
