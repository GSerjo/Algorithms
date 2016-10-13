<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Numerics.dll</Reference>
  <Namespace>System.Numerics</Namespace>
</Query>

// https://www.hackerrank.com/challenges/xoring-ninja
private static BigInteger Mod = new BigInteger(1000000007);

void Main()
{
//	var input = new Input();
	
//	var tests = int.Parse(input.ReadLine());
	var tests = int.Parse(Console.ReadLine());
	
	var result = new List<string>();
	for (int i = 0; i < tests; i++)
	{
//		input.ReadLine();
//		var items = input.ReadLine().Split(' ').Select(BigInteger.Parse).ToList();
		
		Console.ReadLine();
		var items = Console.ReadLine().Split(' ').Select(BigInteger.Parse).ToList();

		result.Add(Xor(items).ToString());
	}
	
	result.ForEach(Console.WriteLine);
}

private static BigInteger Xor(List<BigInteger> list)
{
	var result = BigInteger.Zero;

	foreach(var item in list)
	{
		result |= item;
		result %=Mod;
	}
	var powerset = BigInteger.Pow(new BigInteger(2), list.Count - 1);
	result = BigInteger.Multiply(result, powerset);
	result %= Mod;
	return result;
}


private class Input
{
	private string _path = @"C:\Users\Serjo\Desktop\input.txt";
	private string[] _data;
	private int _lastIndex = -1;

	public Input()
	{
		_data = File.ReadAllLines(_path);
	}

	public string Line(int index)
	{
		_lastIndex = index;
		return _data[index];
	}

	public string ReadLine()
	{
		_lastIndex++;
		return _data[_lastIndex];
	}
}
