<Query Kind="Program" />

/*

https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/

Given an array of integers that is already sorted in ascending order, find two numbers such that they add up to a specific target number.

The function twoSum should return indices of the two numbers such that they add up to the target, where index1 must be less than index2. Please note that your returned answers (both index1 and index2) are not zero-based.

You may assume that each input would have exactly one solution and you may not use the same element twice.

Input: numbers={2, 7, 11, 15}, target=9
Output: index1=1, index2=2

*/

void Main()
{
	TwoSum(new[] {2, 3, 4}, 6).Dump();
}

private static int[] TwoSum(int[] numbers, int target)
{
	for (int i = 0; i < numbers.Length; i++)
	{
		var index = Array.BinarySearch(numbers, i + 1, numbers.Length - i - 1, target - numbers[i]);
		if (index > 0)
		{
			return new int[] { i + 1, index + 1};
		}
	}
	throw new ArgumentException();
}