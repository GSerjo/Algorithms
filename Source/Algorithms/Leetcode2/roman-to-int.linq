<Query Kind="Program" />

void Main()
{
	RomanToInt("XCIX").Dump();
}

private static int RomanToInt(string s)
{
	int[] nums = new int[s.Length];
	for (int i = 0; i < s.Length; i++)
	{
		switch (s[i])
		{
			case 'M':
				nums[i] = 1000;
				break;
			case 'D':
				nums[i] = 500;
				break;
			case 'C':
				nums[i] = 100;
				break;
			case 'L':
				nums[i] = 50;
				break;
			case 'X':
				nums[i] = 10;
				break;
			case 'V':
				nums[i] = 5;
				break;
			case 'I':
				nums[i] = 1;
				break;
		}
	}
	int sum = 0;
	for (int i = 0; i < nums.Length - 1; i++)
	{
		if (nums[i] < nums[i + 1])
			sum -= nums[i];
		else
			sum += nums[i];
	}
	return sum + nums[nums.Length - 1];
}
