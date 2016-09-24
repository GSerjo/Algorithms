<Query Kind="Program" />

// https://www.hackerrank.com/challenges/sherlock-and-the-beast

void Main()
{
//	var testCount = int.Parse(Input.Next());
	var testCount = int.Parse(Console.ReadLine());
	
	var result = new List<string>();
	for (int test = 0; test < testCount; test++)
	{
//		var value = int.Parse(Input.Next());
		var value = int.Parse(Console.ReadLine());
		
		var testResult = string.Empty;
		for (int i = value; i >= 0; i--)
		{
			if(i % 3 == 0 && (value - i)%5 == 0)
			{
				testResult = new string('5',i) + new string('3', value - i);
				break;
			}
		}
		if(string.IsNullOrWhiteSpace(testResult))
		{
			result.Add("-1");
		}
		else
		{
			result.Add(testResult);
		}
	}
	result.ForEach(Console.WriteLine);
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