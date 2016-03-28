using System.Text;

namespace Algorithms.Exrensions
{
    public static class StringExtensions
    {
        public static string Reverse(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return string.Empty;
            }
            var start = 0;
            int end = value.Length - 1;
            var result = new StringBuilder(value);
            while (end > start)
            {
                char dummy = result[start];
                result[start] = result[end];
                result[end] = dummy;
                end--;
                start++;
            }
            return result.ToString();
        }
    }
}