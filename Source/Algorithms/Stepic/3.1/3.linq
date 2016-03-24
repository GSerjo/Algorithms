<Query Kind="Program" />

void Main()
{
	int number = int.Parse(Console.ReadLine());
	List<int> result = GetSummands(number);
	
	Console.WriteLine(result.Count);
	Console.WriteLine(string.Join(" ", result));
}

private static List<int> GetSummands(int number)
{
	List<int> result = new List<int>();
	if (number <= 2)
	{
		result.Add(number);
		return result;
    }
	int summnad = 0;
	while (number != 0)
	{
		summnad++;
		if (number >= summnad)
		{
			number-= summnad;
			result.Add(summnad);
		}
		else
		{
			result[result.Count - 1] = summnad + (number - 1);
			number = 0;
		}
	}
	return result;
}