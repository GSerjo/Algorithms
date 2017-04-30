<Query Kind="Program" />

/*
https://leetcode.com/problems/remove-duplicates-from-sorted-array/

Given a sorted array, remove the duplicates in place such that each element appear only once and return the new length.

Do not allocate extra space for another array, you must do this in place with constant memory.

For example,
Given input array nums = [1,1,2],

Your function should return length = 2, with the first two elements of nums being 1 and 2 respectively. It doesn't matter what you leave beyond the new length.
*/

void Main()
{
	var array = new[]{1, 1, 2};
	RemoveDuplicates(array).Dump();
	array.Dump();
}

private static int RemoveDuplicates(int[] nums)
{
	if(nums == null || nums.Length == 0)
	{
		return 0;
	}
	if(nums.Length == 1)
	{
		return nums[0];
	}
	var result = 1;
	for (int i = 1; i < nums.Length; i++)
	{
		if(nums[i - 1] != nums[i])
		{
			nums[result] = nums[i];
			result++;
		}
	}
	return result;
}