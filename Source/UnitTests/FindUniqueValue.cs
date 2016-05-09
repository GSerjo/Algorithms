using Xunit;

namespace UnitTests
{
    public sealed class FindUniqueValue
    {
        [Fact]
        public void HasUnique()
        {
            var array = new[] { 1, 2, 3, 4, 1, 2, 3, 4, 5 };
            int unique = FindUnique(array);
            Assert.Equal(5, unique);
        }

        private static int FindUnique(int[] array)
        {
            int result = array[0];

            for (var i = 1; i < array.Length; i++)
            {
                result = result ^ array[i];
            }
            return result;
        }
    }
}
