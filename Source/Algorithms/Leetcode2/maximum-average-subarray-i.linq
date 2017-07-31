<Query Kind="Program" />

void Main()
{
	FindMaxAverage(new int[] {4433,-7832,-5068,4009,2830,6544,-6119,-7126,-780,-4254,-8249,-9168,9492,402,5789,6808,8953,5810,-7353,7933,4766,5182,-3230,-1989,5786,6922,-4646,4415,-9906,807,-6373,3370,2604,8751,-9173,-2668,-6876,9500,3465,-1900,4134,-1758,-1453,-5201,-9825,4469,-1999,-1108,1836,3923,6796,-5252,9863,-5997,-3251,9596,-3404,-540,2826,-1737,3341,-3623,-9885,2603,-5782,8174,2710,6504,-4128} , 59).Dump();
	
	FindMaxAverage(new int[] { 5 } , 1).Dump();
}

private static double FindMaxAverage(int[] nums, int k)
{
	var sum = 0;
	var window = 0;
	
	for (int i = 0; i < k; i++)
	{
		sum += nums[i];		
	}
	window = sum;
	for (int i = k; i < nums.Length; i++)
	{
		window = window - nums[i - k] + nums[i];
		sum = Math.Max(window, sum);
	}
	return (double)sum/(double)k;
}
