<Query Kind="Program" />

/*

https://leetcode.com/problems/array-partition-i/

Given an array of 2n integers, your task is to group these integers into n pairs of integer, say (a1, b1), (a2, b2), ..., (an, bn) which makes sum of min(ai, bi) for all i from 1 to n as large as possible.

Example 1:
Input: [1,4,3,2]

Output: 4
Explanation: n is 2, and the maximum sum of pairs is 4.

*/

void Main()
{
	ArrayPairSum(new[] { 1, 4, 3, 2}).Dump();
}

private static int ArrayPairSum(int[] nums)
{
	if (nums == null || nums.Length == 0)
	{
		return 0;
	}
	
	Array.Sort(nums);
	var result = 0;
	for (int i = 0; i < nums.Length; i += 2)
	{
		result += nums[i];
	}
	return result;
}