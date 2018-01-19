<Query Kind="Program" />

void Main()
{
	var n = int.Parse(Console.ReadLine());
	Console.WriteLine(Fib(n));
}

private static long Fib(long n)
{
	if(n == 0 || n == 1)
	{
		return n;
	}
	var fib0 = 0;
	var fib1 = 1;
	for (int i = 2; i < n; i++)
	{
		var fib = fib0 + fib1;
		fib0 = fib1;
		fib1 = fib;
	}
	return fib0 + fib1;
}
