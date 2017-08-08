<Query Kind="Program" />

void Main()
{
	//FindMin(new[] { 4, 5, 6, 7, 0, 1, 2 }).Dump();
	//FindMin(new[] {0, 1, 2, 4, 5, 6, 7 }).Dump();
	//FindMin(new[] {2, 1 }).Dump();
	FindMin(new[] {3, 1, 2 }).Dump();
}

private int FindMin(int[] nums)
{
	if (nums == null || nums.Length == 0)
	{
		return 0;
	}
	var lo = 0;
	var hi = nums.Length - 1;
	var mid = 0;
	while (lo < hi)
	{
		mid = lo + (hi - lo) / 2;
		if (nums[lo] <= nums[mid] && nums[lo] > nums[hi])
		{
			lo = mid + 1;
		}
		else if(nums[lo] <= nums[mid] && nums[mid] < nums[hi])
		{
			hi = mid - 1;
		}
		else if(nums[mid] < nums[lo] && nums[lo] > nums[hi])
		{
			hi = mid;
		}
	}
	return nums[lo];
}