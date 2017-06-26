<Query Kind="Program" />

void Main()
{
	maxSubArray(new[] {-2,1,-3,4,-1,2,1,-5,4}).Dump();
	maxSubArray1(new[] {-2,1,-3,4,-1,2,1,-5,4}).Dump();
}

public int maxSubArray1(int[] nums)
{
	int length = nums.Length;
	int[] result = new int[length];
	result[0] = nums[0];
	int max = result[0];

	for (int i = 1; i < length; i++)
	{
		result[i] = nums[i] + (result[i - 1] > 0 ? result[i - 1] : 0);
		max = Math.Max(max, result[i]);
	}

	return max;
}

private static int maxSubArray(int[] nums)
{
	if (nums == null || nums.Length == 0)
	{
		return 0;
	}
	return maxSubArray(nums, 0, nums.Length - 1);
}

private static int maxSubArray(int[] nums, int lo, int hi)
{
	if (nums == null || nums.Length == 0)
	{
		return 0;
	}
	if (lo == hi)
	{
		return nums[lo];
	}
	var mid = (lo + hi)/2;
	var left = maxSubArray(nums, lo, mid);
	var right = maxSubArray(nums, mid + 1, hi);
	var cross = maxCross(nums, lo, mid, hi);

	if (left > right && left > cross)
	{
		return left;
	}
	if (right > left && right > cross)
	{
		return right;
	}
	return cross;
}

private static int maxCross(int[] nums, int lo, int mid, int hi)
{
	if (lo == hi)
	{
		return nums[lo];
	}
	var sumLeft = int.MinValue;
	var sum = 0;
	for (int i = mid; i > lo; i--)
	{
		sum += nums[i];
		if (sum > sumLeft)
		{
			sumLeft = sum;
		}
	}
	var sumRight = int.MinValue;
	sum = 0;
	for (int i = mid; i < hi; i++)
	{
		sum += nums[i];
		if (sum > sumRight)
		{
			sumRight = sum;
		}
	}
	if (sumLeft == int.MinValue)
	{
		return sumRight;
	}
	if (sumRight == int.MinValue)
	{
		return sumLeft;
	}
	return sumLeft + sumRight;
}