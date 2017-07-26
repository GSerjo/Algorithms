<Query Kind="Program" />

void Main()
{
	SingleNumber(new[] {1, 2, 1, 2, 5}).Dump();
}

public static int SingleNumber(int[] nums)
{
	if (nums.Length == 1)
	{
		return nums[0];
	}
	var dummy = nums[0];
	
	for (int i = 1; i < nums.Length; i++)
	{
		dummy = dummy ^ nums[i];
	}
	return dummy;
}
