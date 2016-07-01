<Query Kind="Program" />

// https://leetcode.com/problems/count-primes/

void Main()
{
	countPrimes1(3);
}


public int countPrimes1(int n)
{
	if (n < 3) return 0;
	bool[] notPrime = new bool[n];
	int result = 0;
	for (int i = 2; i < n; i++)
	{
		if (notPrime[i]) continue;
		for (int k = 2; k * i < n; k++) notPrime[k * i] = true;
		result++;
	}
	return result;
}

private static int CountPrimes(int n)
{
	var result = 0;
	
	for (int i = 1; i < n; i++)
	{
		if(IsPrime(i))
		{
			result++;
		}
	}
	
	return result;
}

public static bool IsPrime(int value)
{
	if (value == 1)
	{
		return false;
	}
	if (value == 2)
	{
		return true;
	}
	
	int boundary = (int)Math.Floor(Math.Sqrt(value));
	for (int i = 2; i <= boundary; ++i)
	{
		if (value % i == 0)
		{
			return false;
		}
	}

	return true;
}

