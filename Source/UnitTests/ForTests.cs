using Xunit;

namespace UnitTests
{
    public sealed class ForTests
    {
        [Fact]
        public void Test()
        {
            var result = GetValue(")()(");
            result = GetValue("()()");
            result = GetValue("((())");
        }

        private static bool GetValue(string value)
        {
            var openPretences = 0;
            var closedPretences = 0;

            foreach (char item in value)
            {
                if (item == ')' && closedPretences >= openPretences)
                {
                    return false;
                }
                if (item == '(')
                {
                    openPretences++;
                    continue;
                }
                if (openPretences > closedPretences && item == ')')
                {
                    closedPretences++;
                }
            }
            return openPretences == closedPretences;
        }
    }
}
