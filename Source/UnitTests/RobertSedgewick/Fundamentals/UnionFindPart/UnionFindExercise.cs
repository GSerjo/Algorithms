using System;
using System.Collections.Generic;
using System.Linq;
using Algorithms.RobertSedgewick.Fundamentals.UnionFindPart;
using Nelibur.Core.Extensions;
using Xunit;

namespace UnitTests.RobertSedgewick.Fundamentals.UnionFindPart
{
    public sealed class UnionFindExercise : UnionFindTest
    {
        [Fact]
        public void UnionFind_Exercise()
        {
            string filePath = @"DataStore\Exercises\Week1\QuickFind.txt";
            int capacity = FileCapacity(filePath);
            var unionFind = new QuickFind(capacity);
            IEnumerable<int[]> data = FileData(filePath);
            data.Iter(x =>
            {
                unionFind.Union(x[0], x[1]);
                Console.WriteLine("{0} - {1}", x[0], x[1]);
                Console.WriteLine(ArrayToString(unionFind.Id));
            });
        }

        [Fact]
        public void WeightedQuickUnion_Exercise()
        {
            string filePath = @"DataStore\Exercises\Week1\WeightedQuickUnion.txt";
            int capacity = FileCapacity(filePath);
            var unionFind = new WeightedQuickUnion(capacity);
            IEnumerable<int[]> data = FileData(filePath);
            Console.WriteLine(ArrayToString(Enumerable.Range(0, 10)));
            data.Iter(x =>
            {
                unionFind.Union(x[0], x[1]);
                Console.WriteLine("{0} - {1}", x[0], x[1]);
                Console.WriteLine(ArrayToString(unionFind.Id));
            });
            Console.WriteLine(SpaceArray(ArrayToString(unionFind.Id)));
        }

        [Fact]
        public void IsWeightedQuickUnion_Exercise()
        {
            var unionFind = new WeightedQuickUnion(10);
            var input = new List<int[]>
            {
                new[] {9, 9, 7, 1, 5, 7, 7, 7, 8, 6 },
//                new[] {8, 3, 8, 2, 2, 8, 8, 8, 8, 5 },
//                new[] {9, 1, 9, 3, 4, 7, 6, 7, 8, 9 },
//                new[] {2, 2, 5, 0, 2, 3, 2, 2, 7, 0 }, //circle
//                new[] {2, 4, 2, 6, 0, 0, 0, 0, 0, 5 }

            };
            var max = Math.Log(10, 2);
            foreach (var values in input)
            {
                unionFind.SetId(values);

                foreach (var item in values)
                {
                    var depth = unionFind.Depth(item);
                    Console.WriteLine("Depth: {0}", depth);
                    if (depth >= max)
                    {
                        Console.WriteLine(ArrayToString(values));
                    }
                }
            }
        }

        private string SpaceArray(string value)
        {
            return string.Join(" ", value.Split(',').Select(x => x.Trim()));
        }
    }
}
