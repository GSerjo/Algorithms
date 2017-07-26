<Query Kind="Program" />

void Main()
{
	var array = new[] {0, 1, 0, 3, 12};
	MoveZeroes(array);
	
	array.Dump();
}

public void MoveZeroes(int[] nums)
{
	if (nums == null || nums.Length <= 1)
	{
		return;
	}
	
	int zero = -1;
	
	for (int i = 0; i < nums.Length; i++)
	{
		if (nums[i] == 0)
		{
			if (zero == -1)
			{
				zero = i;
			}
		}
		else
		{
			if (zero == -1)
			{
				continue;
			}
			var dummy = nums[i];
			nums[i] = 0;
			nums[zero] = dummy;
			zero++;
		}
	}
}
