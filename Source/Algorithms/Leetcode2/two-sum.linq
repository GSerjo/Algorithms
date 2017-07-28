<Query Kind="Program" />

void Main()
{
	TwoSum(new[] {3, 2, 4}, 6).Dump(); 
}

private static int[] TwoSum(int[] nums, int target)
{
	if (nums == null || nums.Length == 0)
	{
		return new int[0];
	}
	
	var data = new Dictionary<int, int>();
	for (int i = 0; i < nums.Length; i++)
	{
		data[nums[i]] = i;
	}
	
	for (int i = 0; i < nums.Length; i++)
	{
		var search = target - nums[i];
		if (data.ContainsKey(search))
		{
			var index = data[search];
			if (index != i)
			{
				return new int[] { i, index };
			}
		}
	}
	
	return new int[0];
}
