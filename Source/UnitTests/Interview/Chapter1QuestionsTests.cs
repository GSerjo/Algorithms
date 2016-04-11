using Algorithms.Interview;
using Xunit;

namespace UnitTests.Interview
{
    public sealed class Chapter1QuestionsTests
    {
        [InlineData("", true)]
        [InlineData(null, true)]
        [InlineData("abcdef", true)]
        [InlineData("abcde ff", false)]
        [Theory]
        public void AllUniqueCharacters(string value, bool expected)
        {
            bool result = Chapter1Questions.AllUniqueCharacters(value);
            Assert.Equal(expected, result);
        }
    }
}
