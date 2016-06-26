<Query Kind="Program" />

// https://leetcode.com/problems/merge-sorted-array/

void Main()
{
	var nums1 = new int[10];
	nums1[0] = 1;
	nums1[1] = 3;
	nums1[2] = 5;
	
	var nums2 = new[]{2, 4, 6};
	
	Merge(nums1, 3, nums2, 3);
}

private static void Merge(int[] nums1, int m, int[] nums2, int n)
{
	if(nums1 == null)
	{
		nums1 = nums2;
	}
	if(nums2 == null)
	{
		return;
	}
	
	var current1 = m - 1;
	var current2 = n - 1;
	var current = n + m - 1;
	
	while (current2 >= 0)
	{
		if(current1 < 0)
		{
			nums1[current--] = nums2[current2--];
			continue;
		}
		if(nums1[current1] > nums2[current2])
		{
			nums1[current--] = nums1[current1--];
		}
		else
		{
			nums1[current--] = nums2[current2--];
		}
	}
}
