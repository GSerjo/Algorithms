<Query Kind="Program" />

void Main()
{
	var value = Console.ReadLine().Split(' ');
	Console.WriteLine(Gcd(int.Parse(value[0]), int.Parse(value[1])));
	//Gcd(14159572, 63967072).Dump();
}

private static int Gcd(int a, int b)
{
	if(a == 0)
	{
		return b;
	}
	if(b == 0)
	{
		return a;
	}
	if(a > b)
	{
		return Gcd(a % b, b);
	}
	return Gcd(a, b % a);
}
