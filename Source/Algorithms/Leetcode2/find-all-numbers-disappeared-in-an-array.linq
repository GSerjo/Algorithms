<Query Kind="Program" />

void Main()
{
	FindDisappearedNumbers(new[] {1, 1}).Dump();
}

private static IList<int> FindDisappearedNumbers(int[] nums)
{
	if (nums == null || nums.Length == 0)
	{
		return new List<int>();
	}
	Array.Sort(nums);

	var result = new List<int>();
	if (nums.Length == 1 && nums[0] != 1)
	{
		for (int i = 1; i < nums[0]; i++)
		{
			result.Add(i);
		}
		return result;
	}

	int counter = 1;
	for (int i = 0; i < nums.Length; i++)
	{
		if (nums[i] == counter)
		{
			counter++;
			continue;
		}
		result.Add(counter);
		
	}

	return result;
}
