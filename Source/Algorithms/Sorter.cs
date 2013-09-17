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

        public static List<int> Merge(IEnumerable<int> list)
        {
            var queue = new Queue<List<int>>();
            foreach (int value in list)
            {
                queue.Enqueue(new List<int> { value });
            }
            while (queue.Count > 1)
            {
                List<int> merge = MergeCore(queue.Dequeue(), queue.Dequeue());
                queue.Enqueue(merge);
            }
            return queue.Dequeue();
        }


        public static void Quick(List<int> list, int start, int end)
        {
            if (start >= end)
            {
                return;
            }
            int pivot = Partition(list, start, end);
            Quick(list, start, pivot - 1);
            Quick(list, pivot + 1, end);
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

        private static List<int> MergeCore(List<int> first, List<int> second)
        {
            int firstIndex = 0;
            int secondIndex = 0;
            var result = new List<int>();
            while (firstIndex < first.Count && secondIndex < second.Count)
            {
                if (first[firstIndex] < second[secondIndex])
                {
                    result.Add(first[firstIndex]);
                    firstIndex++;
                }
                else
                {
                    result.Add(second[secondIndex]);
                    secondIndex++;
                }
            }
            if (firstIndex == first.Count)
            {
                second.RemoveRange(0, secondIndex);
                result.AddRange(second);
            }
            else
            {
                first.RemoveRange(0, firstIndex);
                result.AddRange(first);
            }
            return result;
        }

        private static int Partition(IList<int> list, int start, int end)
        {
            int i = start;
            int p = end == list.Count ? end - 1 : end;
            for (int j = start; j < end; j++)
            {
                if (list[j] < list[p])
                {
                    Swap(list, j, i);
                    i++;
                }
            }
            if (end == list.Count)
            {
                return i;
            }
            Swap(list, end, i);
            return i;
        }

        private static void Swap(IList<int> list, int first, int second)
        {
            int dummy = list[first];
            list[first] = list[second];
            list[second] = dummy;
        }
    }
}
