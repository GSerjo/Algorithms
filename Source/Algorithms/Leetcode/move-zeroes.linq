<Query Kind="Program" />

/*
https://leetcode.com/problems/move-zeroes/

Given an array nums, write a function to move all 0's to the end of it while maintaining the relative order of the non-zero elements.

For example, given nums = [0, 1, 0, 3, 12], after calling your function, nums should be [1, 3, 12, 0, 0].

Note:
You must do this in-place without making a copy of the array.
Minimize the total number of operations.
*/

void Main()
{
	var array = new[] {0, 1, 0, 3, 12};
	MoveZeroes(array);
	array.Dump();

	array = new[] { 0, 0, 1 };
	MoveZeroes(array);
	array.Dump();

	array = new[] { 1, 2, 3 };
	MoveZeroes(array);
	array.Dump();

	array = new[] { 2, 0, 1 };
	MoveZeroes(array);
	array.Dump();

	array = new[] { 0, 1, 0, 3, 12 };
	MoveZeroes2(array);
	array.Dump();

	array = new[] { 0, 0, 1 };
	MoveZeroes2(array);
	array.Dump();

	array = new[] { 1, 2, 3 };
	MoveZeroes2(array);
	array.Dump();

	array = new[] { 2, 0, 1 };
	MoveZeroes2(array);
	array.Dump();

}

private static void MoveZeroes2(int[] nums)
{
	if (nums == null || nums.Length == 0)
	{
		return;
	}
	var currentIndex = 0;
	for (int i = 0; i < nums.Length; i++)
	{
		if(nums[i] == 0)
		{
			continue;
		}
		if(currentIndex == i)
		{
			currentIndex++;
			continue;
		}
		var temp = nums[i];
		nums[i] = nums[currentIndex];
		nums[currentIndex] = temp;
		currentIndex++;
	}
}

private static void MoveZeroes(int[] nums)
{
	if(nums == null || nums.Length == 0)
	{
		return;
	}
	var currentIndex = 0;
	while (currentIndex < nums.Length)
	{
		if (nums[currentIndex] != 0)
		{
			currentIndex++;
			continue;
		}
		var nonZeroIndex = FindNonZeroIndex(nums, currentIndex + 1);
		if(nonZeroIndex == -1)
		{
			break;
		}
		else
		{
			var temp = nums[currentIndex];
			nums[currentIndex] = nums[nonZeroIndex];
			nums[nonZeroIndex] = temp;
			currentIndex++;
		}
	}
}

private static int FindNonZeroIndex(int[] nums, int startIndex)
{
	if(startIndex  >= nums.Length)
	{
		return -1;
	}
	for (int i = startIndex; i < nums.Length; i++)
	{
		if(nums[i] != 0)
		{
			return i;
		}
	}
	return -1;
}