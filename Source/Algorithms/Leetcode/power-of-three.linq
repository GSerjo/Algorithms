<Query Kind="Program" />

// https://leetcode.com/problems/power-of-three/

void Main()
{
	IsPowerOfThree(27).Dump();
}
public bool IsPowerOfThree(int n)
{
	if (n < 1)
	{
		return false;
	}
	
	int max = 1162261467; //3 ^ 19 < int.max 3^20 > int.max
	return max % n == 0;
}
