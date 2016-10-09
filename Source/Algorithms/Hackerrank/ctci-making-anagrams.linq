<Query Kind="Program" />

// https://www.hackerrank.com/challenges/ctci-making-anagrams
void Main()
{
//	var input = new Input();
//	var first = input.Next().Trim().ToCharArray();
//	var second = input.Next().Trim().ToCharArray().OrderBy(x=>x).ToList();
	
	var first = Console.ReadLine().Trim().ToCharArray();
	var second = Console.ReadLine().Trim().ToCharArray().OrderBy(x=>x).ToList();
	
	if(first.Length == 0 && second.Count == 0)
	{
		Console.WriteLine(0);
		return;
	}
	
	var result = 0;
	for (int i = 0; i < first.Length; i++)
	{
		var index = second.BinarySearch(first[i]);
		if(index < 0)
		{
			result++;
		}
		else
		{
			second.RemoveAt(index);
		}
	}
	result = result + second.Count;
	Console.WriteLine(result);
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

	public string Next()
	{
		_lastIndex++;
		return _data[_lastIndex];
	}
}
