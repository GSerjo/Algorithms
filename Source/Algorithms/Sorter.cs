using System.Collections.Generic;

namespace Algorithms
{
    public static class Sorter
    {
        public static List<int> Selection(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                int min = i;
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[j] < list[min])
                    {
                        min = j;
                    }
                }
                int dummy = list[i];
                list[i] = list[min];
                list[min] = dummy;
            }
            return list;
        }
    }
}
