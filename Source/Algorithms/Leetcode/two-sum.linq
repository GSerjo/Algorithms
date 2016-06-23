<Query Kind="Program" />

// https://leetcode.com/problems/two-sum/

void Main()
{
	TwoSum(new[] {2, 7, 11, 15}, 9).Dump();
}

private static int[] TwoSum(int[] nums, int target)
{
	var result = new List<int>();
	var cache = new Dictionary<int, int>();
	
	for (int i = 0; i < nums.Length; i++)
	{
		if (cache.ContainsKey(nums[i]))
		{
			result.Add(cache[nums[i]]);
			result.Add(i);
			return result.ToArray();
		}
		else
		{
		
			cache[target - nums[i]] = i;
		}
	}
	return result.ToArray();
}