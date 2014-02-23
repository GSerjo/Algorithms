using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using Algorithms.RobertSedgewick.UnionFindPart;
using Xunit;

namespace UnitTests.RobertSedgewick.UnionFindPart
{
    public sealed class QuickFindTest
    {
        private const string LargeFile = @"DataStore\largeUF.txt";
        private const string TinyFile = @"DataStore\tinyUF.txt";

        [Fact(Skip="Too slow")]
        public void Union_Performance()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            IEnumerable<string> lines = File.ReadLines(LargeFile);
            var unionFind = new QuickFind(int.Parse(lines.First()));
            IEnumerable<int[]> data = GetData(lines);
            foreach (var item in data)
            {
                unionFind.Union(item[0], item[1]);
            }
            stopwatch.Stop();
            Console.WriteLine("TotalMilliseconds: {0}", stopwatch.Elapsed.TotalMilliseconds);
        }

        [Fact]
        public void Union_TinyFile()
        {
            IEnumerable<string> lines = File.ReadLines(TinyFile);
            var unionFind = new QuickFind(int.Parse(lines.First()));
            IEnumerable<int[]> data = GetData(lines);
            foreach (var item in data)
            {
                unionFind.Union(item[0], item[1]);
                Console.WriteLine(ArrayToString(unionFind.Indexes));
            }
            Assert.Equal(new[] { 1, 1, 1, 8, 8, 1, 1, 1, 8, 8 }, unionFind.Indexes);
        }

        private static string ArrayToString<T>(IEnumerable<T> array)
        {
            var result = new StringBuilder();

            foreach (T element in array)
            {
                if (result.Length > 0)
                {
                    result.Append(", ");
                }

                result.Append(element);
            }

            result.Insert(0, "{");
            result.Append("}");
            return result.ToString();
        }

        private static IEnumerable<int[]> GetData(IEnumerable<string> lines)
        {
            IEnumerable<int[]> data = lines.Skip(1).Select(x => x.Split(' '))
                                           .Select(x => new[] { int.Parse(x[0]), int.Parse(x[1]) });
            return data;
        }
    }
}
