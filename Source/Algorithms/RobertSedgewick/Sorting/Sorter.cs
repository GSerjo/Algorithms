using System;

namespace Algorithms.RobertSedgewick.Sorting
{
    public abstract class Sorter
    {
        public bool IsSorted(IComparable[] value)
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

        protected static void Exchange(IComparable[] value, int i, int j)
        {
            IComparable temp = value[i];
            value[i] = value[j];
            value[j] = temp;
        }

        protected static bool Less(IComparable left, IComparable right)
        {
            return left.CompareTo(right) < 0;
        }
    }
}
