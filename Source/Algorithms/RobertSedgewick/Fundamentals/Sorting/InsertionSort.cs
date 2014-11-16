using System;

namespace Algorithms.RobertSedgewick.Fundamentals.Sorting
{
    public static class InsertionSort
    {
        public static void Sort<T>(T[] array)
            where T : IComparable
        {
            for (int i = 1; i < array.Length; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (Less(array[j], array[j - 1]))
                    {
                        Exchage(array, j, j - 1);
                    }
                }
            }
        }

        private static void Exchage<T>(T[] array, int i, int j)
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
