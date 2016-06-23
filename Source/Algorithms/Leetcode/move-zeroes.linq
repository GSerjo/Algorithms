<Query Kind="Program" />

// https://leetcode.com/problems/move-zeroes/

void Main()
{
	var nums = new[] {0, 1, 0, 3, 12 };
	MoveZeroes(nums);
	nums.Dump();
}

private static void MoveZeroes(int[] nums)
{
	if (nums == null || nums.Length == 0 || nums.Length == 1)
	{
		return;
	}
	
	int insertIndex = -1;
	for (int i = 0; i < nums.Length; i++)
	{
		if (nums[i] == 0)
		{
			if (insertIndex == -1)
			{
				insertIndex = i;
			}
		}
		else if(insertIndex != -1)
		{
			nums[insertIndex] = nums[i];
			insertIndex++;
		}
	}
	if (insertIndex == -1)
	{
		return;
	}
	
	for (int i = insertIndex; i < nums.Length; i++)
	{
		nums[i] = 0;
	}	
}


