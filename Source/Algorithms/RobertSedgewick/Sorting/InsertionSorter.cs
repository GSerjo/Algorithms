using System;

namespace Algorithms.RobertSedgewick.Sorting
{
    public sealed class InsertionSorter : Sorter
    {
        public static T[] Sort<T>(T[] value)
            where T : IComparable
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
