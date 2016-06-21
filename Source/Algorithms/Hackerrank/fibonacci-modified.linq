<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Numerics.dll</Reference>
  <Namespace>System.Numerics</Namespace>
</Query>

// https://www.hackerrank.com/challenges/fibonacci-modified
void Main()
{
//	var input = Console.ReadLine().Split(' ').Select(x=>long.Parse(x)).ToArray();
	var input = Input.Line(0).Split(' ').Select(x=>BigInteger.Parse(x)).ToArray();
	var result = Calculate(input[0], input[1], input[2]);
	Console.WriteLine(result);
}

private static BigInteger Calculate(BigInteger a, BigInteger b, BigInteger n)
{
	if (n == 1)
	{
		return a;
	}
	if (n == 2)
	{
		return b;
	}
	BigInteger result = 0;
	for (int i = 3; i < n; i++)
	{
		result = b * b + a;
		a = b;
		b = result;
	}
	result = b * b + a;
	return result;
}
