<Query Kind="Program" />

void Main()
{
	TwoSum(new[] {2, 7, 11, 15}, 9).Dump();
}

public int[] TwoSum(int[] nums, int target)
{
	var cache = new Dictionary<int, int>();
	for (int i = 0; i < nums.Length; i++)
	{
		cache[nums[i]] = i;
	}
	
	for (int i = 0; i < nums.Length; i++)
	{
		var value = target - nums[i];
		if(cache.ContainsKey(value))
		{
			var index = cache[value];
			if(index != i)
			{
				return new []{i, index};
			}
		}
	}
	throw new ArgumentException();
}