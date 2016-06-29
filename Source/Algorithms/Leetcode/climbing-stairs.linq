<Query Kind="Program" />

// https://leetcode.com/problems/climbing-stairs/

void Main()
{
	ClimbStairs(4).Dump();
}

private static int ClimbStairs(int n)
{
	if(n <=2 )
	{
		return n;
	}
	
	var step2 = 2;
	var step1 = 1;
	var step = 0;
	for (int i = 3; i < n; i++)
	{
		step = step2 + step1;
		step1 = step2;
		step2 = step;
	}
	return step2 + step1;
}
