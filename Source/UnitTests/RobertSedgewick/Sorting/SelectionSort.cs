using System;

namespace UnitTests.RobertSedgewick.Sorting
{
    public static class SelectionSort
    {
        public static void Sort(IComparable[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int min = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (Less(array[j], array[min]))
                    {
                        min = j;
                    }
                }
                Exchange(array, i, min);
            }
        }

        private static void Exchange(IComparable[] array, int i, int j)
        {
            IComparable temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        private static bool Less(IComparable first, IComparable second)
        {
            return first.CompareTo(second) < 0;
        }
    }
}
