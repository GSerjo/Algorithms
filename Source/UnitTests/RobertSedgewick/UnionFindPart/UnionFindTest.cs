using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace UnitTests.RobertSedgewick.UnionFindPart
{
    public abstract class UnionFindTest
    {
        protected const string LargeFile = @"DataStore\largeUF.txt";
        protected const string TinyFile = @"DataStore\tinyUF.txt";

        protected static string ArrayToString<T>(IEnumerable<T> array)
        {
            var result = new StringBuilder();

            foreach (T element in array)
            {
                if (result.Length > 0)
                {
                    result.Append(", ");
                }

                result.Append(element);
            }

            result.Insert(0, "{");
            result.Append("}");
            return result.ToString();
        }

        protected static int FileCapacity(string filePath)
        {
            return int.Parse(File.ReadLines(filePath).First());
        }

        protected static IEnumerable<int[]> FileData(string filePath)
        {
            IEnumerable<string> lines = File.ReadLines(filePath);
            IEnumerable<int[]> data = lines.Skip(1).Select(x => x.Split(' '))
                                           .Select(x => new[] { int.Parse(x[0]), int.Parse(x[1]) });
            return data;
        }
    }
}
