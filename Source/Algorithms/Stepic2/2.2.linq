<Query Kind="Program" />

void Main()
{
	var value = int.Parse(Console.ReadLine());
	Console.WriteLine(Fib(value));
}

private static int Fib(int value)
{
	if(value <= 1)
	{
		return value;
	}
	var dummy0 = 0;
	var dummy1 = 1;
	for (int i = 2; i < value; i++)
	{
		var dummy = dummy0 + dummy1;
		dummy0 = dummy1;
		dummy1 = dummy;
	}
	return dummy1 + dummy0;
}
