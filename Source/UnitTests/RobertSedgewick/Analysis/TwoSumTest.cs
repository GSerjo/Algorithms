using System;
using System.Diagnostics;
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
            int result = TwoSum.Quick(path);
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
            int result = TwoSum.Slow(path);
            stopwatch.Stop();
            Console.WriteLine(
                "File: {0} Time: {1} ms Result: {2}", path, stopwatch.Elapsed.TotalMilliseconds, result);
        }
    }
}
