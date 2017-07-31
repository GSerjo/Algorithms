<Query Kind="Program" />

void Main()
{
	
}

private static bool ContainsDuplicate(int[] nums)
{
	if (nums == null || nums.Length <= 1)
	{
		return false;
	}
	
	var cache = new HashSet<int>();
	foreach (var item in nums)
	{
		if (cache.Contains(item))
		{
			return true;
		}
		cache.Add(item);
	}
	return false;
}