using System;
using System.Collections.Generic;

namespace Algorithms.RobertSedgewick.Sorting
{
    public sealed class MergeSorter : Sorter
    {
        public static T[] Sort<T>(T[] value)
            where T : IComparable
        {
            var queue = new Queue<List<T>>();
            Array.ForEach(value, x => queue.Enqueue(new List<T> { x }));
            while (queue.Count > 1)
            {
                queue.Enqueue(Merge(queue.Dequeue(), queue.Dequeue()));
            }
            return queue.Dequeue().ToArray();
        }

        private static List<T> Merge<T>(List<T> first, List<T> second)
            where T : IComparable
        {
            var result = new List<T>();
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
