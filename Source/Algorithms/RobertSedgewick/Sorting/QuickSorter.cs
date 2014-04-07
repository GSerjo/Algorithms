using System;

namespace Algorithms.RobertSedgewick.Sorting
{
    public sealed class QuickSorter : Sorter
    {
        public static T[] Sort<T>(T[] value)
            where T : IComparable
        {
            Sort(value, 0, value.Length - 1);
            return value;
        }

        private static int Partition<T>(T[] value, int start, int end)
            where T : IComparable
        {
            int i = start;
            int j = end + 1;
            T partitionItem = value[start];
            while (true)
            {
                while (Less(value[++i], partitionItem))
                {
                    if (i == end)
                    {
                        break;
                    }
                }
                while (Less(partitionItem, value[--j]))
                {
                    if (j == start)
                    {
                        break;
                    }
                }
                if (i >= j)
                {
                    break;
                }
                Exchange(value, i, j);
            }
            Exchange(value, start, j);
            return j;
        }

        private static void Sort<T>(T[] value, int start, int end)
            where T : IComparable
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
