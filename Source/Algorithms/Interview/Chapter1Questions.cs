using System.Collections.Generic;

namespace Algorithms.Interview
{
    public static class Chapter1Questions
    {
        /// <summary>
        /// Implement an algorithm to determine if a string has all unique characters.
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
    }
}
