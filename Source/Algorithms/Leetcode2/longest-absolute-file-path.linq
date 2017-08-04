<Query Kind="Program" />

void Main()
{
	LengthLongestPath("dir\n\tsubdir1\n\t\tfile1.ext\n\t\tsubsubdir1\n\tsubdir2\n\t\tsubsubdir2\n\t\t\tfile2.ext").Dump();
	//LengthLongestPath("dir\n\tsubdir1\n\tsubdir2\n\t\tfile.ext").Dump();
}

public static int LengthLongestPath(string input)
{
	if (string.IsNullOrEmpty(input))
	{
		return 0;
	}
	var result = 0;
	var tokens = input.Split('\n');
	var cache = new Dictionary<int, int>();
	
	foreach (var token in tokens)
	{
		var dummy = token.Replace("\t", string.Empty);
		var level = token.Length - dummy.Length;

		var upLevel = 0;
		if (level > 0)
		{
			upLevel = cache[level - 1] + 1; // +1 for '/'
		}
		cache[level] = dummy.Length + upLevel;

		if (IsFile(token))
		{
			result = Math.Max(result, cache[level]);
		}
	}
	
	return result;
}

private static bool IsFile(string token)
{
	return token.Contains(".");
}
