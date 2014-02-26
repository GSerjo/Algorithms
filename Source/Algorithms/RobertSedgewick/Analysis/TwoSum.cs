﻿using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Algorithms.RobertSedgewick.Analysis
{
    public static class TwoSum
    {
        public static int Quick(string sourceDataPath)
        {
            int result = 0;
            List<int> source = Data(sourceDataPath);
            source.Sort();
            for (int i = 0; i < source.Count; i++)
            {
                int searchValue = -source[i];
                if (source.BinarySearch(searchValue) > i)
                {
                    result++;
                }
            }
            return result;
        }

        public static int Slow(string sourceDataPath)
        {
            int result = 0;
            List<int> source = Data(sourceDataPath);
            for (int i = 0; i < source.Count; i++)
            {
                for (int j = i + 1; j < source.Count; j++)
                {
                    if (source[i] + source[j] == 0)
                    {
                        result++;
                    }
                }
            }
            return result;
        }

        private static List<int> Data(string sourceDataPath)
        {
            return File.ReadLines(sourceDataPath)
                       .Select(int.Parse)
                       .ToList();
        }
    }
}
