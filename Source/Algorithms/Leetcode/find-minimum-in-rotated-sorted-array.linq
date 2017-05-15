<Query Kind="Program" />

/*

https://leetcode.com/problems/find-minimum-in-rotated-sorted-array

Suppose an array sorted in ascending order is rotated at some pivot unknown to you beforehand.

(i.e., 0 1 2 4 5 6 7 might become 4 5 6 7 0 1 2,  6 7 0 1 2 4 5).

Find the minimum element.

You may assume no duplicate exists in the array.

*/

void Main()
{
	FindMin(new int[] {4, 5, 6, 7, 0, 1, 2}).Dump();
	FindMin(new int[] {6, 7, 0, 1, 2, 4, 5}).Dump();
	FindMin(new int[] {2, 1, 0}).Dump();
}

private static int FindMin(int[] nums)
{
	if (nums == null || nums.Length == 0)
	{
		throw new ArgumentException();
	}
	if (nums.Length == 1)
	{
		return nums[0];
	}
	var lo = 0;
	var hi = nums.Length - 1;

	while (lo < hi)
	{
		if (nums[lo] < nums[hi])
		{
			return nums[lo];
		}
		var mid = lo + (hi - lo)/ 2;
		if (nums[mid] > nums[lo])
		{
			lo = mid + 1;
		}
		else
		{
			if (nums[mid] > nums[hi])
			{
				lo = mid + 1;
			}
			else
			{
				hi = mid;
			}
		}
	}
	return nums[lo];	
}