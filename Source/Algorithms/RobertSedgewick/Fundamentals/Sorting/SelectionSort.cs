using System;

namespace Algorithms.RobertSedgewick.Fundamentals.Sorting
{
    public static class SelectionSort
    {
        public static void Sort<T>(T[] array)
            where T : IComparable
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

        private static void Exchange<T>(T[] array, int i, int j)
        {
            T temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        private static bool Less<T>(T first, T second)
            where T : IComparable

        {
            return first.CompareTo(second) < 0;
        }
    }
}
