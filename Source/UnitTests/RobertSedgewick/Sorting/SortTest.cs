using System;

namespace UnitTests.RobertSedgewick.Sorting
{
    public abstract class SortTest
    {
        public bool IsSorted<T>(T[] array)
            where T : IComparable
        {
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i].CompareTo(array[i - 1]) < 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
