<Query Kind="Program" />

void Main()
{
	ContainsDuplicate(new int[] {1, 1, 3, 4}).Dump();
}

public bool ContainsDuplicate(int[] nums)
{
	if(nums == null || nums.Length == 1)
	{
		return false;
	}
	var cache = new HashSet<int>();
	foreach (var item in nums)
	{
		if(cache.Contains(item))
		{
			return true;
		}
		else
		{
			cache.Add(item);
		}
	}
	return false;
}
