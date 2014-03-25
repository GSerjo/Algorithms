using System;

namespace Algorithms.RobertSedgewick.Sorting
{
    public sealed class InsertionSorter : Sorter
    {
        public static IComparable[] Sort(IComparable[] value)
        {
            for (int i = 1; i < value.Length; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (Less(value[j], value[j - 1]))
                    {
                        Exchange(value, j, j - 1);
                    }
                }
            }
            return value;
        }
    }
}
