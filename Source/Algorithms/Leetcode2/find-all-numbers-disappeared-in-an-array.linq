<Query Kind="Program" />

void Main()
{
	FindDisappearedNumbers(new[] {1, 1}).Dump();
	
	FindDisappearedNumbers(new[] {2, 2}).Dump();

	FindDisappearedNumbers(new[] {4,3,2,7,8,2,3,1}).Dump();
}

private static IList<int> FindDisappearedNumbers(int[] nums)
{
	if (nums == null || nums.Length == 0)
	{
		return new List<int>();
	}
	Array.Sort(nums);

	var result = new List<int>();
	int counter = 0;
	
	for (int i = 0; i < nums.Length; i++)
	{
		if (nums[i] - counter <= 1)
		{
			counter = nums[i];
			continue;
		}
		
		for (int j = counter + 1; j < nums[i]; j++)
		{
			result.Add(j);
		}
		counter = nums[i];
	}
	
	var last = nums[nums.Length - 1];
	if (last != nums.Length)
	{
		for (int i = last + 1; i <= nums.Length; i++)
		{
			result.Add(i);
		}
	}

	return result;
}