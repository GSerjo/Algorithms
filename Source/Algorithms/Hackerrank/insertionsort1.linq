<Query Kind="Program" />

//https://www.hackerrank.com/challenges/insertionsort1

void Main()
{
	Console.ReadLine();
	var list = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToList();
//	var list = Input.Line(1).Split(' ').Select(x => int.Parse(x)).ToList();

	var result = new List<string>();
	
	for (int i = 1; i < list.Count; i++)
	{
		int j = i;
		int tempItem = list[j];
		while (j > 0 && tempItem < list[j - 1])
		{
			list[j] = list[j-1];
			j = j - 1;
			result.Add(string.Join(" ", list));
		}
		if(j != i)
		{
			list[j] = tempItem;
		}
	}
	result.Add(string.Join(" ", list));
	result.ForEach(x=>Console.WriteLine(x));
}
