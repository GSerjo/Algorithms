<Query Kind="Program" />

// https://leetcode.com/problems/add-digits/

void Main()
{
	AddDigits(38).Dump();
}

private static int AddDigits(int num)
{
	if (num == 0)
	{
		return 0;
	}
	var result = num - 9* (Math.Floor(((double)(num - 1)/9)));
	return (int)result;
}