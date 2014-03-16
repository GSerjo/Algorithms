using System.Collections.Generic;

namespace Algorithms.RobertSedgewick.Analysis
{
    public static class TwoSum
    {
        public static int Quick(List<int> source)
        {
            int result = 0;
            source.Sort();
            for (int i = 0; i < source.Count; i++)
            {
                if (source[i] > 0)
                {
                    return result;
                }
                int searchValue = -source[i];
                if (source.BinarySearch(searchValue) > i)
                {
                    result++;
                }
            }
            return result;
        }

        public static int Slow(List<int> source)
        {
            int result = 0;
            for (int i = 0; i < source.Count; i++)
            {
                for (int j = i + 1; j < source.Count; j++)
                {
                    if (source[i] + source[j] == 0)
                    {
                        result++;
                    }
                }
            }
            return result;
        }
    }
}
