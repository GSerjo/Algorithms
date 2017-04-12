<Query Kind="Program" />

/*
https://leetcode.com/problems/contains-duplicate/

Given an array of integers, find if the array contains any duplicates.
Your function should return true if any value appears at least twice in the array,
and it should return false if every element is distinct.
*/

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