using System;

namespace Algorithms.RobertSedgewick.Sorting
{
    public sealed class ShellSorter : Sorter
    {
        public static void Sort(IComparable[] value)
        {
            int h = 1;
            while (h < value.Length/3)
            {
                h = h*3 + 1;
            }
            while (h >= 1)
            {
                for (int i = h; i < value.Length; i++)
                {
                    for (int j = i; j >= h; j -= h)
                    {
                        if (Less(value[j], value[j - h]))
                        {
                            Exchange(value, j, j - h);
                        }
                    }
                }
                h = h/3;
            }
        }
    }
}
