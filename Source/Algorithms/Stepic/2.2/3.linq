<Query Kind="Program" />

void Main()
{
	//GetPisano(1000000000000000000, 5).Dump();
	FibLastDigit(10, 2).Dump();
}

private static long FibLastDigit(long n, long m)
{
	if (n <= 1)
	{
		return n;
	}
	
	List<long> pisano = GetPisano(1000000000000000000, m);
	int index = (int)(n % pisano.Count);
	return pisano[index];
}

private static List<long> GetPisano(long n, long m)
{
	var result = new List<long>();
	result.Add(0);
	result.Add(1);
	
	long dummy0 = 0;
	long dummy1 = 1;

	for (int i = 2; i < n; i++)
	{
		long lastDigit = (dummy0 + dummy1) % m;
		result.Add(lastDigit);
		dummy0 = dummy1;
		dummy1 = lastDigit;
		
		if (dummy0 == 0 && dummy1 == 1)
		{
			result.RemoveAt(result.Count - 1);
			result.RemoveAt(result.Count - 1);
			return result;
		}
	}
	return result;
}
