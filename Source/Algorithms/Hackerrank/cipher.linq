<Query Kind="Program" />

// https://www.hackerrank.com/challenges/cipher

void Main()
{
//	var input = new Input();
//	var inputData = input.ReadLine().Split(' ');
	
	var inputData = Console.ReadLine().Split(' ');
	
	var length = int.Parse(inputData[0]);
	var shift = int.Parse(inputData[1]);
	
//	var word = input.ReadLine();
	var word = Console.ReadLine();
	
	var ones = 0;
	var result = new StringBuilder();
	for (int i = 0; i < length; i++)
	{
		if(i > shift - 1)
		{
			var remove = result[i - shift];
			if (!IsZero(remove))
			{
				ones--;
			}
		}
		var item = XorValue(ones, word[i]);
		result.Append(item);
		
		if(!IsZero(item))
		{
			ones++;
		}
	}
	Console.WriteLine(result.ToString());
}

private static bool IsZero(char value)
{
	return '0' == value;
}

private static char XorValue(int ones, char targetXor)
{
	var hasOne = ones%2 != 0;
	if(!hasOne)
	{
		return targetXor;
	}
	if(IsZero(targetXor))
	{
		return '1';
	}
	return '0';
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