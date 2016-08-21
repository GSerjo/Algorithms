<Query Kind="Program" />

//https://leetcode.com/problems/reverse-string/

//Example:
//Given s = "hello", return "olleh".

void Main()
{
	Reverse("hello").Dump();
}

private static string Reverse(string value)
{
	if(string.IsNullOrWhiteSpace(value))
	{
		return value;
	}
	var result = new StringBuilder(value);
	var min = 0;
	var max = value.Length - 1;
	while (min < max)
	{
		var temp = result[min];
		result[min] = result[max];
		result[max] = temp;
		min++;
		max--;
	}
	return result.ToString();
}
