<Query Kind="Program" />

void Main()
{
	ArrayPairSum(new[] {1,4,3,2}).Dump();
}

public int ArrayPairSum(int[] nums)
{
	if(nums == null || nums.Length == 0)
	{
		return 0;
	}
	Array.Sort(nums);
	var result = 0;
	
	for (int i = 0; i < nums.Length; i += 2)
	{
		result += nums[i];
	}
	return result;
}
