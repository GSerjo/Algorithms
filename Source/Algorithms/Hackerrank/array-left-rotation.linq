<Query Kind="Program" />

//https://www.hackerrank.com/challenges/array-left-rotation

void Main()
{
//	var input = new Input();
//	var shift = int.Parse(input.ReadLine().Split(' ')[1]);
//	var array = input.ReadLine().Split(' ').Select(int.Parse).ToList();

	var shift = int.Parse(Console.ReadLine().Split(' ')[1]);
	var array = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

	var offset = shift > array.Count ? shift % array.Count : shift;
	if(offset == 0)
	{
		Console.WriteLine(string.Join(" ", array));
		return;
	}
	var result = new int[array.Count];
	for (int i = 0; i < array.Count; i++)
	{
		if(i < offset)
		{
			var j = array.Count - (offset - i);
			result[j] = array[i];
		}
		else
		{
			var j = i - offset;
			result[j] = array[i];
		}
	}
	Console.WriteLine(string.Join(" ", result));
}

private static void Swap(List<int> array, int i, int j)
{
	var temp = array[i];
	array[i] = array[j];
	array[j] = temp;
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
