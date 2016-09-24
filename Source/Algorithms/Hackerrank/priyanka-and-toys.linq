<Query Kind="Program" />

// https://www.hackerrank.com/challenges/priyanka-and-toys

void Main()
{
	Console.ReadLine();	
	var items = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

//	Input.Next();
//	var items = Input.Next().Split(' ').Select(int.Parse).ToList();
	
	items = items.OrderBy(x => x).ToList();
	
	if(items.Count == 0)
	{
		Console.WriteLine(0);
		return;
	}
	
	var result = 1;
	var currentItem = items[0];
	foreach (var item in items.Skip(0))
	{
		if(item > currentItem + 4)
		{
			result = result + 1;
			currentItem = item;
		}
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
