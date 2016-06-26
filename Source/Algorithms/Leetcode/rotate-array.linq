<Query Kind="Program" />

// https://leetcode.com/problems/rotate-array/

void Main()
{
	var data = new[]{1, 2, 3, 4, 5, 6, 7};
	Rotate(data, 3);
	data.Dump();
}

private static void Rotate(int[] nums, int k)
{
	if(nums == null || nums.Length == 0)
	{
		return;
	}
	
	var result = new int[nums.Length];
	
	for (int i = 0; i < nums.Length; i++)
	{
		var newIndex = (i + k) % nums.Length;
		result[newIndex] = nums[i];
	}
	
	Array.Copy(result, nums, result.Length);
}