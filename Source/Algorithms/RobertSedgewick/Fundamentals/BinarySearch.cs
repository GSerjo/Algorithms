namespace Algorithms.RobertSedgewick.Fundamentals
{
    public static class BinarySearch
    {
        public static int Search(int key, int[] data)
        {
            if (data == null || data.Length == 0)
            {
                return -1;
            }
            var lo = 0;
            int hi = data.Length - 1;

            while (lo <= hi)
            {
                int med = lo + (hi - lo) / 2;
                if (key > data[med])
                {
                    lo = med + 1;
                }
                else if (key < data[med])
                {
                    hi = med - 1;
                }
                else
                {
                    return med;
                }
            }
            return -1;
        }
    }
}
