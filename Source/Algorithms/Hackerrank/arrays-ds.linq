<Query Kind="Program" />

//https://www.hackerrank.com/challenges/arrays-ds
void Main()
{
	Console.ReadLine();
	var input = Console.ReadLine();
	if(string.IsNullOrWhiteSpace(input))
	{
		Console.WriteLine(string.Empty);
		return;
	}
	Console.WriteLine(string.Join(" ", input.Split(' ').Reverse().ToArray()));
}
