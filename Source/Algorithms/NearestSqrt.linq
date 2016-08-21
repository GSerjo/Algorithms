<Query Kind="Program" />

void Main()
{
	NearestSqrt(10).Dump();
}

private static int NearestSqrt(int value)
{
	if(value == 0 || value == 1)
	{
		return value;
	}
	var min = 1;
	var max = value;

	while(min <= max)
	{
		var mid = (min + max) /2;
		if(value - mid * mid == 0)
		{
			return mid;
		}
		if(value - mid*mid > 0)
		{
			min = mid + 1;
		}
		else
		{
			max = mid - 1;
		}
	}
	if(Math.Abs(value - min*min) < Math.Abs(value - max*max))
	{
		return min;
	}
	return max;
}

