<Query Kind="Program" />

// https://www.hackerrank.com/challenges/greedy-florist

void Main()
{
	var input = new Input();
	var friends = int.Parse(input.Next().Split(' ')[1]);
	var prices = input.Next().Split(' ').Select(int.Parse).OrderByDescending(x=>x).ToList();
	
	var purchasedFlowers = 0;
	var result = 0; 
	for (int i = 0; i < prices.Count; i++)
	{
		if(i % friends == 0 && i != 0)
		{
			purchasedFlowers++;
		}
		result += (purchasedFlowers + 1) * prices[i];
	}
	
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
