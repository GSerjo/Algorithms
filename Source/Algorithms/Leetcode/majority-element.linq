<Query Kind="Program" />

/*
https://leetcode.com/problems/majority-element/

Given an array of size n, find the majority element. The majority element is the element that appears more than ⌊ n/2 ⌋ times.
You may assume that the array is non-empty and the majority element always exist in the array.

*/

void Main()
{
	MajorityElement(new[] {1, 1, 2, 2, 1}).Dump();
}

private static int MajorityElement(int[] nums)
{
	var count = 1;
	int result = nums[0];
	for (int i = 1; i < nums.Length; i++)
	{
		if(count == 0)
		{
			result = nums[i];
			count = 1;
			continue;
		}
		if(result == nums[i])
		{
			count++;
		}
		else
		{
			count--;
		}
	}
	return result;
}