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

        public static int FindMultipleLength(int[] array)
        {
            if (array == null || array.Length == 0)
            {
                return 0;
            }
            var result = 0;
            var cache = new int[array.Length];
            for (var i = 0; i < array.Length; i++)
            {
                cache[i] = 1;
                for (int j = i - 1; j >= 0; j--)
                {
                    if (array[j] > array[i])
                    {
                        continue;
                    }
                    if (array[i] % array[j] != 0)
                    {
                        continue;
                    }
                    if (cache[j] + 1 > cache[i])
                    {
                        cache[i] = cache[j] + 1;
                    }
                }
                if (cache[i] > result)
                {
                    result = cache[i];
                }
            }
            return result;
        }
    }
}
