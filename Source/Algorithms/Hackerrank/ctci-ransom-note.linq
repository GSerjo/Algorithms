<Query Kind="Program" />

// https://www.hackerrank.com/challenges/ctci-ransom-note

void Main()
{
//	var input = new Input();
//	input.ReadLine();
//	
//	var source = input.ReadLine().Split(' ');
//	var target = input.ReadLine().Split(' ');

	Console.ReadLine();

	var source = Console.ReadLine().Split(' ');
	var target = Console.ReadLine().Split(' ');

	if(source.Length == 0 && target.Length > 0)
	{
		Console.WriteLine("No");
		return;
	}
	var dictionary = new Dictionary<string, int>();
	
	foreach (var item in source)
	{
		if(dictionary.ContainsKey(item))
		{
			dictionary[item]++;
		}
		else
		{
			dictionary[item] = 1;
		}
	}
	
	foreach (var item in target)
	{
		if(!dictionary.ContainsKey(item))
		{
			Console.WriteLine("No");
			return;
		}
		else
		{
			dictionary[item] -= 1;
			
			if(dictionary[item] < 0)
			{
				Console.WriteLine("No");
				return;
			}
		}
	}
	Console.WriteLine("Yes");
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
