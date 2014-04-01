using System;

namespace Algorithms.RobertSedgewick.Sorting
{
    public abstract class Sorter
    {
        public static bool IsSorted<T>(T[] value)
            where T : IComparable
        {
            for (int i = 1; i < value.Length; i++)
            {
                if (Less(value[i], value[i - 1]))
                {
                    return false;
                }
            }
            return true;
        }

        protected static void Exchange<T>(T[] value, int i, int j)
            where T : IComparable
        {
            T temp = value[i];
            value[i] = value[j];
            value[j] = temp;
        }

        protected static bool Less<T>(T left, T right)
            where T : IComparable
        {
            return left.CompareTo(right) < 0;
        }
    }
}
