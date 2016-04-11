using System.Collections.Generic;
using System.Text;

namespace Algorithms.Interview
{
    public static class Chapter1Questions
    {
        /// <summary>
        ///     Implement an algorithm to determine if a string has all unique characters.
        /// </summary>
        public static bool AllUniqueCharacters(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return true;
            }
            var hash = new HashSet<char>();
            foreach (char symbol in value)
            {
                if (hash.Contains(symbol))
                {
                    return false;
                }
                hash.Add(symbol);
            }
            return true;
        }

        /// <summary>
        ///     Reverse string.
        /// </summary>
        public static string Reverse(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return value;
            }
            var lo = 0;
            int hi = value.Length - 1;
            var result = new StringBuilder(value);
            while (lo < hi)
            {
                char dummy = result[lo];
                result[lo] = result[hi];
                result[hi] = dummy;
                lo++;
                hi--;
            }
            return result.ToString();
        }
    }
}
