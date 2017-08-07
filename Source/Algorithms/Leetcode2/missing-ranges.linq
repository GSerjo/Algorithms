<Query Kind="Program" />

void Main()
{
	//FindMissingRanges(new[] {0, 1, 3, 50, 75}, 0, 99).Dump();
	FindMissingRanges(new int[] {-2147483648,2147483647}, -2147483648, 2147483647).Dump();
}

private IList<string> FindMissingRanges(int[] nums, int lower, int upper)
{
	if (nums == null || nums.Length == 0)
	{
		return new List<string> { Range(lower, upper)};
	}
	
	var result = new List<string>();
	if (nums[0] - lower > 0)
	{
		result.Add(Range(lower, nums[0] - 1));
		lower = nums[0];
	}
	
	for (int i = 1; i < nums.Length; i++)
	{
		if ((long)nums[i] - (long)lower >= 2)
		{
			result.Add(Range(lower + 1, nums[i] - 1));
		}
		lower = nums[i];
	}

	if ((long)upper - (long)nums[nums.Length - 1] >= 1)
	{
		result.Add(Range(nums[nums.Length - 1] + 1, upper));
	}
	
	return result;
}

private string Range(int lo, int hi)
{
	if (lo == hi)
	{
		return lo.ToString();
	}
	return string.Format("{0}->{1}", lo, hi);
}
