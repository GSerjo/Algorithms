<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Numerics.dll</Reference>
  <Namespace>System.Numerics</Namespace>
</Query>

/*
https://leetcode.com/problems/find-all-numbers-disappeared-in-an-array/

Given an array of integers where 1 ≤ a[i] ≤ n (n = size of array), some elements appear twice and others appear once.

Find all the elements of [1, n] inclusive that do not appear in this array.

Could you do it without extra space and in O(n) runtime? You may assume the returned list does not count as extra space.

Example:

Input:
[4,3,2,7,8,2,3,1]

Output:
[5,6]

*/

void Main()
{
	FindDisappearedNumbers(new[] {4,3,2,7,8,2,3,1}).Dump();
}


private static IList<int> FindDisappearedNumbers(int[] nums)
{
	if (nums == null || nums.Length == 0)
	{
		return new List<int>();
	}
	var result = new List<int>();
	int mask = 0;
	foreach (var item in nums)
	{
		mask |= 1 << item;
	}
	
	for (int i = 1; i <= nums.Length; i++)
	{
		if (((mask >> i) & 1) != 1)
		{
			result.Add(i);
		}
	}
	return result;
}