<Query Kind="Program" />

/*

https://leetcode.com/problems/intersection-of-two-arrays/

Given two arrays, write a function to compute their intersection.

Example:
Given nums1 = [1, 2, 2, 1], nums2 = [2, 2], return [2].

Note:
Each element in the result must be unique.
The result can be in any order.

*/

void Main()
{
	Intersection(new[] { 1, 2, 2, 1 }, new[] {2, 2}).Dump();
}

private static int[] Intersection(int[] nums1, int[] nums2)
{
	var result = new List<int>();
	var intersection = new HashSet<int>();
	var hashSet1 = new HashSet<int>();

	if (nums1 != null && nums1.Length > 0)
	{
		foreach (var item in nums1)
		{
			if (!hashSet1.Contains(item))
			{
				hashSet1.Add(item);
			}
		}
	}

	if (nums2 != null && hashSet1.Count > 0)
	{
		foreach (var item in nums2)
		{
			if (hashSet1.Contains(item) && !intersection.Contains(item))
			{
				result.Add(item);
				intersection.Add(item);
			}
		}
	}
	return result.ToArray();
	
}