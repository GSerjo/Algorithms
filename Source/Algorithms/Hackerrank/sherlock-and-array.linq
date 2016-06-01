<Query Kind="Program" />

//https://www.hackerrank.com/challenges/sherlock-and-array

void Main()
{
	var input = int.Parse(Console.ReadLine());
//	var input = int.Parse(Input.Line(0));
	var result = new List<string>();
	
	for (int i = 1; i <= input; i++)
	{
		Console.ReadLine();
		var line = Console.ReadLine().Split(' ').Select(x=>int.Parse(x)).ToArray();
//		var line = Input.Line(i*2).Split(' ').Select(x=>int.Parse(x)).ToArray();
		result.Add(CheckArray(line));
	}
	result.ForEach(x=>Console.WriteLine(x));
}

private static string CheckArray(int[] array)
{
	if (array == null || array.Length == 0)
	{
		return "NO";
	}
	if (array.Length == 1)
	{
		return "YES";
	}

	int lo = 0;
	int hi = array.Length - 1;
	int leftSum = array[lo];
	int rightSum = array[hi];
	
	while(lo < hi)
	{
		if(lo + 2 == hi)
		{
			break;
		}
		if(leftSum > rightSum)
		{
			hi--;
			rightSum+=array[hi];
		}
		else
		{
			lo++;
			leftSum+=array[lo];
		}
	}
	
	return leftSum == rightSum ? "YES" : "NO";
}