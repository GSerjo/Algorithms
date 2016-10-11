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
	
	var zeros = 0;
	var ones = 0;
	var result = new StringBuilder();
	for (int i = 0; i < length; i++)
	{
		if(i > shift - 1)
		{
			var remove = result[i - shift];
			if (IsZero(remove))
			{
				zeros--;
			}
			else
			{
				ones--;
			}
		}
		var item = XorValue(zeros, ones, word[i]);
		result.Append(item);
		
		if(IsZero(item))
		{
			zeros++;
		}
		else
		{
			ones++;
		}
	}
	Console.WriteLine(result.ToString());
}

private bool IsZero(char value)
{
	return '0' == value;
}

private char XorValue(int zeros, int ones, char targetXor)
{
	var hasZero = zeros%2 != 0;
	var hasOne = ones%2 != 0;
	if(!hasOne && !hasOne)
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