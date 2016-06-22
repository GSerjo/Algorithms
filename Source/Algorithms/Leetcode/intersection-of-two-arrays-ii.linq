<Query Kind="Program" />

// https://leetcode.com/problems/intersection-of-two-arrays-ii/

void Main()
{
	Intersection(new[] { 1, 2, 2, 1 }, new[] { 2, 2 }).Dump();
}

private static int[] Intersection(int[] nums1, int[] nums2)
{
	if (nums1 == null || nums2 == null || nums1.Length == 0 || nums2.Length == 0)
	{
		return new int[0];
	}
	nums1 = nums1.OrderBy(x => x).ToArray();
	nums2 = nums2.OrderBy(x => x).ToArray();

	var result = new List<int>();

	int index1 = 0;
	int index2 = 0;
	while (index1 < nums1.Length && index2 < nums2.Length)
	{
		if (nums1[index1] == nums2[index2])
		{
			result.Add(nums1[index1]);
			index1++;
			index2++;
		}
		else if (nums1[index1] > nums2[index2])
		{
			index2++;
		}
		else
		{
			index1++;
		}
	}
	return result.ToArray();
}

