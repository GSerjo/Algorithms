<Query Kind="Program" />

/* 
https://leetcode.com/problems/two-sum

Given nums = [2, 7, 11, 15], target = 9,

Because nums[0] + nums[1] = 2 + 7 = 9,
return [0, 1].

*/

void Main()
{
	TwoSum(new[] {2, 7, 11, 15}, 9).Dump();
}

private static int[] TwoSum(int[] nums, int target)
{
	var cache = new Dictionary<int, int>();
	
	for (int i = 0; i < nums.Length; i++)
	{
		if (cache.ContainsKey(nums[i]))
		{
			return new[] {cache[nums[i]], i};
		}
		else
		{
			cache[target - nums[i]] = i;
		}
	}
	throw new ArgumentException();
}