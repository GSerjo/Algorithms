<Query Kind="Program" />

/*
https://leetcode.com/problems/single-number/

Given an array of integers, every element appears twice except for one. Find that single one.
*/

void Main()
{
	SingleNumber(new[] {0, 0, 1, 1, 2}).Dump();
}

private static int SingleNumber(int[] nums)
{
	if (nums == null || nums.Length == 0)
	{
		throw new ArgumentException();
	}
	var result = nums[0];
	
	for (int i = 1; i < nums.Length; i++)
	{
		result ^= nums[i];
	}
	return result;
}