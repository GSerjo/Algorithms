using System;

namespace Algorithms.RobertSedgewick.Sorting
{
    public sealed class QuickSorter : Sorter
    {
        public static IComparable[] Sort(IComparable[] value)
        {
            Sort(value, 0, value.Length - 1);
            return value;
        }

        private static int Partition(IComparable[] value, int start, int end)
        {
            int i = start;
            int j = end + 1;
            IComparable partitionItem = value[start];
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
