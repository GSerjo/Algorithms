<Query Kind="Program" />

// https://leetcode.com/problems/power-of-two/

void Main()
{



}


private static bool IsPowerOfTwo(int n)
{
	if(n <= 0)
	{
		return false;
	}
	
	while(n%2 == 0)
	{
		n = n/2;
	}
	return n == 1;
}
