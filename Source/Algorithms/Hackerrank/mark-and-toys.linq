<Query Kind="Program" />

// https://www.hackerrank.com/challenges/mark-and-toys

void Main()
{
//	var money = int.Parse(Input.Next().Split(' ')[1]);
//	var prices = Input.Next().Split(' ').Select(int.Parse).OrderBy(x=>x).ToList();

	var money = int.Parse(Console.ReadLine().Split(' ')[1]);
	var prices = Console.ReadLine().Split(' ').Select(int.Parse).OrderBy(x => x).ToList();

	var result = 0;
	foreach (var price in prices)
	{
		money = money - price;
		if(money < 0)
		{
			break;
		}
		result = result + 1;
	}
	Console.WriteLine(result);
}



private static class Input
{
	private static string _path = @"C:\Users\Serjo\Desktop\input.txt";
	private static string[] _data;
	private static int _lastIndex = -1;

	static Input()
	{
		_data = File.ReadAllLines(_path);
	}

	public static string Line(int index)
	{
		_lastIndex = index;
		return _data[index];
	}

	public static string Next()
	{
		_lastIndex++;
		return _data[_lastIndex];
	}
}
