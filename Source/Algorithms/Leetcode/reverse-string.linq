<Query Kind="Program" />

//https://leetcode.com/problems/reverse-string/
void Main()
{
	Reverse("hello").Dump();
}

private static string Reverse(string value)
{
	if (string.IsNullOrEmpty(value) || value.Length < 2)
	{
		return value;
	}
	var start = 0;
	var end = value.Length - 1;
	var result = new StringBuilder(value);
	while (start < end)
	{
		var dummy = result[start];
		result[start] = result[end];
		result[end] = dummy;
		start++;
		end--;
	}
	return result.ToString();
}

// Define other methods and classes here
