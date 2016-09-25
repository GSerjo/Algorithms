<Query Kind="Program" />

// https://www.hackerrank.com/challenges/largest-permutation

void Main()
{
//	var values = Console.ReadLine().Split(' ');
	
	var input = new Input();
	var values = input.Next().Split(' ');
	int n = int.Parse(values[0]);
	int k = int.Parse(values[1]);

	var source = new int[n];
	var index = new int[n + 1];

	var data = input.Next().Split(' ').Select(int.Parse).ToList();

	for (int i = 0; i < data.Count; i++)
	{
		source[i] = data[i];
		index[source[i]] = i;
	}

	for (int i = 0; i < n && k > 0; i++)
	{
		if (source[i] == n - i)
		{
			continue;
		}
		source[index[n - i]] = source[i];
		index[source[i]] = index[n - i];
		source[i] = n - i;
		index[n - i] = i;
		k--;
	}

	Console.WriteLine(string.Join(" ", source));
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