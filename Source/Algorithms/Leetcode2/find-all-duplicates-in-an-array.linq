<Query Kind="Program" />

void Main()
{
	FindDuplicates(new[] { 1, 4, 2, 7, 8, 2, 3, 1}).Dump();
}

private IList<int> FindDuplicates(int[] nums)
{
	if (nums == null || nums.Length == 0)
	{
		return new List<int>();
	}
	var result = new List<int>();

	for (int i = 0; i < nums.Length; i++)
	{
		var index = Math.Abs(nums[i]) - 1;
		if (nums[index] < 0)
		{
			result.Add(Math.Abs(index + 1));
		}
		nums[index] = -nums[index];
	}

	return result;
}
