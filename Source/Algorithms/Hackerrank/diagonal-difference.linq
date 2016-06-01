<Query Kind="Program" />

//https://www.hackerrank.com/challenges/diagonal-difference
void Main()
{
	int inputs = int.Parse(Console.ReadLine());
//	int inputs = int.Parse(Input.Line(0));
	
	int diagonal1 = 0;
	int diagonal2 = 0;
	for (int i = 0; i < inputs; i++)
	{
		var line = Console.ReadLine().Split(' ').Select(x=>int.Parse(x)).ToArray();
//		var line = Input.Line(i + 1).Split(' ').Select(x=>int.Parse(x)).ToArray();
		diagonal1 += line[i];
		diagonal2 += line[line.Length - 1 - i];
	}
	
	Console.WriteLine(Math.Abs(diagonal1 - diagonal2));
}


private static class Input
{
	private static string _path = @"C:\Users\Serjo\Desktop\input.txt";
	private static string[] _data;

	static Input()
	{
		_data = File.ReadAllLines(_path);
	}

	public static string Line(int index)
	{
		return _data[index];
	}
}
