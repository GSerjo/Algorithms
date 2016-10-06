<Query Kind="Program" />

//https://www.hackerrank.com/challenges/lonely-integer
//a ^ 0 = a
//a ^ a = 0
void Main()
{
//	var input = new Input();
//	
//	input.Next();
//	var data = input.Next().Split(' ').Select(int.Parse).ToList();

	Console.ReadLine();
	var data = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

	var result = data.Aggregate(0, (accumulator, x)=>x^accumulator);
	
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