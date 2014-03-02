using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using Algorithms.RobertSedgewick.Analysis;
using Xunit;
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

        [Fact]
        public void Quick_MeasurePerformance()
        {
            int counter = 0;
            TimeSpan previous = Measure(TwoSum.Quick, Data(150));
            for (int i = 250;; i += i)
            {
                TimeSpan current = Measure(TwoSum.Quick, Data(i));
                double ratio = current.TotalMilliseconds/previous.TotalMilliseconds;
                Console.WriteLine("DataLength: {0}, Time: {1} ms Ratio: {2}", i, current.TotalMilliseconds, ratio);
                previous = current;
                counter++;
                if (counter >= 10)
                {
                    break;
                }
            }
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

        [Fact]
        public void Slow_MeasurePerformance()
        {
            int counter = 0;
            TimeSpan previous = Measure(TwoSum.Slow, Data(150));
            for (int i = 250;; i += i)
            {
                TimeSpan current = Measure(TwoSum.Slow, Data(i));
                double ratio = current.TotalMilliseconds/previous.TotalMilliseconds;
                Console.WriteLine("DataLength: {0}, Time: {1} ms Ratio: {2}", i, current.TotalMilliseconds, ratio);
                previous = current;
                counter++;
                if (counter >= 8)
                {
                    break;
                }
            }
        }

        private static List<int> Data(string sourceDataPath)
        {
            return File.ReadLines(sourceDataPath)
                       .Select(int.Parse)
                       .ToList();
        }

        private static List<int> Data(int count)
        {
            var data = new byte[count];
            var provider = new RNGCryptoServiceProvider();
            provider.GetBytes(data);
            return data.Select(Convert.ToInt32).ToList();
        }

        private TimeSpan Measure(Func<List<int>, int> func, List<int> data)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            func(data);
            stopwatch.Stop();
            return stopwatch.Elapsed;
        }
    }
}
