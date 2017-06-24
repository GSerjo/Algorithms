<Query Kind="Program" />

static Random random = new Random();

void Main()
{
	FindKthLargest(new[] {3,2,1,5,6,4}, 1).Dump();
}

public static int FindKthLargest(int[] nums, int k)
{
	return FindKthLargestCore(nums, k);
}

private static int FindKthLargestCore(int[] nums, int k)
{
	if (nums.Length == 1)
	{
		return nums[0];
	}

	var p = random.Next(0, nums.Length);

	var left = nums.Where(x => x > nums[p]).ToArray();
	if (left.Length >= k)
	{
		return FindKthLargestCore(left, k);
	}
	var eq = nums.Where(x => x == nums[p]).ToArray();
	if (left.Length < k && k <= left.Length + eq.Length)
	{
		return eq[0];
	}
	var right = nums.Where(x => x < nums[p]).ToArray();
	return FindKthLargestCore(right, k - left.Length - eq.Length);
}