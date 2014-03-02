using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Algorithms.RobertSedgewick.Analysis;
using Xunit.Extensions;

namespace UnitTests.RobertSedgewick.Analysis
{
    public sealed class TwoSumTest
    {
        [InlineData(@"DataStore\14analysis\1Kints.txt")]
        [InlineData(@"DataStore\14analysis\2Kints.txt")]
        [InlineData(@"DataStore\14analysis\4Kints.txt")]
        [InlineData(@"DataStore\14analysis\8Kints.txt")]
        [InlineData(@"DataStore\14analysis\16Kints.txt")]
        [Theory]
        public void Quick(string path)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            int result = TwoSum.Quick(Data(path));
            stopwatch.Stop();
            Console.WriteLine(
                "File: {0} Time: {1} ms Result: {2}", path, stopwatch.Elapsed.TotalMilliseconds, result);
        }

        [InlineData(@"DataStore\14analysis\1Kints.txt")]
        [InlineData(@"DataStore\14analysis\2Kints.txt")]
        [InlineData(@"DataStore\14analysis\4Kints.txt")]
        [InlineData(@"DataStore\14analysis\8Kints.txt")]
        [InlineData(@"DataStore\14analysis\16Kints.txt")]
        [Theory]
        public void Slow(string path)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            int result = TwoSum.Slow(Data(path));
            stopwatch.Stop();
            Console.WriteLine(
                "File: {0} Time: {1} ms Result: {2}", path, stopwatch.Elapsed.TotalMilliseconds, result);
        }

        private static List<int> Data(string sourceDataPath)
        {
            return File.ReadLines(sourceDataPath)
                       .Select(int.Parse)
                       .ToList();
        }
    }
}
