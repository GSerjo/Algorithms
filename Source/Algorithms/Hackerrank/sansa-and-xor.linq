<Query Kind="Program" />

// https://www.hackerrank.com/challenges/sansa-and-xor

void Main()
{
//	var input = new Input();
//	var count = int.Parse(input.Next());
	
	var count = int.Parse(Console.ReadLine());
	
	var result = new List<int>();
	for (int i = 0; i < count; i++)
	{
//		input.Next();
//		var items = input.Next().Split(' ').Select(int.Parse).ToList();

		Console.ReadLine();
		var items = Console.ReadLine().Split(' ').Select(int.Parse).ToList();


		if(items.Count%2 == 0)
		{
			result.Add(0);
		}
		else
		{
			var xor = 0;
			for (int y = 0; y < items.Count; y++)
			{
				if(y%2==0)
				{
					xor ^=items[y];
				}	
			}
			result.Add(xor);
		}
	}
	
	result.ForEach(Console.WriteLine);
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
