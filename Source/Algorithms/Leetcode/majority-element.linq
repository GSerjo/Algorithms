<Query Kind="Program" />

// https://leetcode.com/problems/majority-element/

void Main()
{
	MajorityElement(new []{1, 1, 3, 4, 3, 3, 3, 69}).Dump();
}

private static int MajorityElement(int[] nums)
{
	if(nums == null || nums.Length == 0)
	{
		return 0;
	}
	
	if(nums.Length <= 2)
	{
		return nums[0];
	}
	
	var majority = nums[0];
	int count = 1;
	
	for (int i = 1; i < nums.Length; i++)
	{
		if(nums[i] == majority)
		{
			count++;
		}
		else
		{
			count --;
		}
		
		if(count == 0)
		{
			majority = nums[i];
			count = 1;
		}
	}
	return majority;	
}
