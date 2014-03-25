using System;
using System.Collections.Generic;

namespace Algorithms.RobertSedgewick.Sorting
{
    public sealed class MergeSorter : Sorter
    {
        public static IComparable[] Sort(IComparable[] value)
        {
            var queue = new Queue<List<IComparable>>();
            Array.ForEach(value, x => queue.Enqueue(new List<IComparable> { x }));
            while (queue.Count > 1)
            {
                queue.Enqueue(Merge(queue.Dequeue(), queue.Dequeue()));
            }
            return queue.Dequeue().ToArray();
        }

        private static List<IComparable> Merge(List<IComparable> first, List<IComparable> second)
        {
            var result = new List<IComparable>();
            int firstIndex = 0;
            int secondIndex = 0;
            while (firstIndex < first.Count && secondIndex < second.Count)
            {
                if (Less(first[firstIndex], second[secondIndex]))
                {
                    result.Add(first[firstIndex++]);
                }
                else
                {
                    result.Add(second[secondIndex++]);
                }
            }
            if (firstIndex < first.Count)
            {
                result.AddRange(first.GetRange(firstIndex, first.Count - firstIndex));
            }
            else
            {
                result.AddRange(second.GetRange(secondIndex, second.Count - secondIndex));
            }
            return result;
        }
    }
}
