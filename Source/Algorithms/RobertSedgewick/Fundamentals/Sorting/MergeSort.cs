using System;

namespace Algorithms.RobertSedgewick.Fundamentals.Sorting
{
    public static class MergeSort
    {
        public static void Sort<T>(T[] array)
            where T : IComparable
        {
            var aux = new T[array.Length];
            Sort(array, aux, 0, array.Length - 1);
        }

        private static bool Less<T>(T first, T second)
            where T : IComparable
        {
            return first.CompareTo(second) < 0;
        }

        private static void Merge<T>(T[] array, T[] aux, int lo, int mid, int hi)
            where T : IComparable
        {
            for (int k = lo; k <= hi; k++)
            {
                aux[k] = array[k];
            }
            int i = lo;
            int j = mid + 1;
            for (int k = lo; k <= hi; k++)
            {
                if (i > mid)
                {
                    array[k] = aux[j++];
                }
                else if (j > hi)
                {
                    array[k] = aux[i++];
                }
                else if (Less(aux[i], aux[j]))
                {
                    array[k] = aux[i++];
                }
                else
                {
                    array[k] = aux[j++];
                }
            }
        }

        private static void Sort<T>(T[] array, T[] aux, int lo, int hi)
            where T : IComparable
        {
            if (hi <= lo)
            {
                return;
            }
            int mid = lo + (hi - lo) / 2;
            Sort(array, aux, lo, mid);
            Sort(array, aux, mid + 1, hi);
            Merge(array, aux, lo, mid, hi);
        }
    }
}
