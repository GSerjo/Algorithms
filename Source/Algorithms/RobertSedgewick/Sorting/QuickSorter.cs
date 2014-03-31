using System;

namespace Algorithms.RobertSedgewick.Sorting
{
    public sealed class QuickSorter : Sorter
    {
        public static IComparable[] Sort(IComparable[] value)
        {
            Sort(value, 0, value.Length);
            return value;
        }

        private static int Partition(IComparable[] value, int start, int end)
        {
            int i = start;
            int hi = value.Length == end ? end - 1 : end;
            for (int j = i; j < hi; j++)
            {
                if (Less(value[j], value[hi]))
                {
                    Exchange(value, j, hi);
                    i++;
                }
            }
            if (end == value.Length)
            {
                return i;
            }
            Exchange(value, end, i);
            return i;
        }

        private static void Sort(IComparable[] value, int start, int end)
        {
            if (start >= end)
            {
                return;
            }
            int pivot = Partition(value, start, end);
            Sort(value, start, pivot - 1);
            Sort(value, pivot + 1, end);
        }
    }
}
