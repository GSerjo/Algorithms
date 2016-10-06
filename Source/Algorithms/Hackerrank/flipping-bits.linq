<Query Kind="Program" />

// https://www.hackerrank.com/challenges/flipping-bits
void Main()
{
	
//	var input = new Input();
//	var count = int.Parse(input.Next());
	
	var count = int.Parse(Console.ReadLine());
	
	var result = new List<UInt32>();
	var max = UInt32.MaxValue;
	for (int i = 0; i < count; i++)
	{
//		var value = uint.Parse(input.Next());
		var value = uint.Parse(Console.ReadLine());
		result.Add(value ^ max);
	}
	
	result.ForEach(Console.WriteLine);
}

private static byte[] Invert(int value)
{
	var result = new byte[32];
	for (int i = 0; i < 32; i++)
	{
		if ((value & (1 << i)) == 0)
			result[i] = 1;
		else
			result[i] = 0;
	}
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

	public string Next()
	{
		_lastIndex++;
		return _data[_lastIndex];
	}
}
