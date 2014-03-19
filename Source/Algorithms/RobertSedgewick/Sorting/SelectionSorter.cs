using System;

namespace Algorithms.RobertSedgewick.Sorting
{
    public sealed class SelectionSorter : Sorter
    {
        public static void Sort(IComparable[] value)
        {
            for (int i = 0; i < value.Length; i++)
            {
                int min = i;
                for (int j = i + 1; j < value.Length; j++)
                {
                    if (Less(value[j], value[min]))
                    {
                        min = j;
                    }
                }
                Exchange(value, i, min);
            }
        }
    }
}
