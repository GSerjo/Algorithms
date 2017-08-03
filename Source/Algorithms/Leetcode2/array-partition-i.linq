<Query Kind="Program" />

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
	var sum = 0;
	Array.Sort(nums);
	
	for (int i = 0; i < nums.Length; i += 2)
	{
		sum += nums[i];
	}
	return sum;
}
