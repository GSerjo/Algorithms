<Query Kind="Program" />

//https://www.hackerrank.com/challenges/insertionsort2

void Main()
{
	Console.ReadLine();
	var list = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToList();
//	var list = Input.Line(1).Split(' ').Select(x => int.Parse(x)).ToList();

	var result = new List<string>();

	for (int i = 1; i < list.Count; i++)
	{
		int j = i;
		
		while (j > 0 && list[j] < list[j - 1])
		{
			int dummy = list[j];
			list[j] = list[j - 1];
			list[j-1] = dummy;
			j = j - 1;
		}
		result.Add(string.Join(" ", list));
	}
	result.ForEach(x => Console.WriteLine(x));
}
