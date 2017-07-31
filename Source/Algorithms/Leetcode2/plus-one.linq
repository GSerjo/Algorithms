<Query Kind="Program" />

void Main()
{
	PlusOne(new[] {9,8,7,6,5,4,3,2,1,0}).Dump();
}

private static int[] PlusOne(int[] digits)
{
	if (digits == null || digits.Length == 0)
	{
		return digits;
	}
	
	var addition = 1;
	for (int i = digits.Length - 1; i >= 0; i--)
	{
		var sum = digits[i] + addition;
		digits[i] = sum % 10;
		if (sum >= 10)
		{
			addition = 1;
		}
		else
		{
			addition = 0;
		}
	}
	if (addition == 1)
	{
		var dummy = new int[digits.Length + 1];
		for (int i = 0; i < digits.Length; i++)
		{
			dummy[i] = digits[i];
		}
		dummy[0] = 1;
		digits = dummy;
	}
	
	return digits;
}
