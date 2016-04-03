using System;
using System.Collections.Generic;

namespace Algorithms.Exrensions
{
    public static class ListExtensions
    {
        public static void Shuffle<T>(this IList<T> collection)
        {
            var random = new Random();
            for (var i = 0; i < collection.Count; i++)
            {
                int j = random.Next(i + 1);
                Swap(collection, i, j);
            }
        }

        private static void Swap<T>(IList<T> collection, int i, int j)
        {
            T dummy = collection[i];
            collection[i] = collection[j];
            collection[j] = dummy;
        }
    }
}
