<Query Kind="Program" />

//https://www.hackerrank.com/challenges/tutorial-intro
void Main()
{

	int value = int.Parse(Console.ReadLine());
	Console.ReadLine();
//	int value = int.Parse(Input.Line(0));
	
	var data = Console.ReadLine().Split(' ').Select(x=>int.Parse(x)).ToList();
//	var data = Input.Line(2).Split(' ').Select(x=>int.Parse(x)).ToList();
	var result = data.BinarySearch(value);
	Console.WriteLine(result);
}
