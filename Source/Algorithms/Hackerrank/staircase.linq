<Query Kind="Program" />

//https://www.hackerrank.com/challenges/staircase
void Main()
{
	var height = int.Parse(Console.ReadLine());
//	var height = 6;
	if(height <= 0)
	{
		return;
	}
	
	for (int i = 1; i <= height; i++)
	{
		var spaces = new string(' ', height - i);
		var symbols = new string('#', i);
		var line = spaces + symbols;
		Console.WriteLine(line);
	}
}

