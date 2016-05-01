namespace Algorithms.DynamicProgramming
{
    public static class LongestIncreasingSubsequence
    {
        public static int FindLength(int[] array)
        {
            if (array == null || array.Length == 0)
            {
                return 0;
            }

            var subSequenceCount = new int[array.Length];
            var result = 0;
            for (var i = 0; i < array.Length; i++)
            {
                subSequenceCount[i] = 1;

                for (int j = i - 1; j >= 0; j--)
                {
                    if (array[j] > array[i])
                    {
                        continue;
                    }
                    if (subSequenceCount[j] + 1 > subSequenceCount[i])
                    {
                        subSequenceCount[i] = subSequenceCount[j] + 1;
                    }
                }
                if (subSequenceCount[i] > result)
                {
                    result = subSequenceCount[i];
                }
            }
            return result;
        }
    }
}
