using System.Collections.Generic;

namespace Algorithms
{
    public static class Sorter
    {
        public static List<int> Insert(List<int> list)
        {
            for (int i = 1; i < list.Count; i++)
            {
                int j = i;
                while (j > 0 && list[j] < list[j - 1])
                {
                    Swap(list, j, j - 1);
                    j = j - 1;
                }
            }
            return list;
        }

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
                Swap(list, i, min);
            }
            return list;
        }

        private static void Swap(IList<int> list, int first, int second)
        {
            int dummy = list[first];
            list[first] = list[second];
            list[second] = dummy;
        }
    }
}
