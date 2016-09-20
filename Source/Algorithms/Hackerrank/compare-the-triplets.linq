<Query Kind="Program" />

// https://www.hackerrank.com/challenges/compare-the-triplets

void Main()
{
//	var firstLine = Input.Line(0);
	var firstLine = Console.ReadLine();
	var firstValues = firstLine.Split(' ').Select(int.Parse).ToList();

//	var secondLine = Input.Line(1);
	var secondLine = Console.ReadLine();
	var secondValues = secondLine.Split(' ').Select(int.Parse).ToList();
	
	var result = Compare(firstValues, secondValues);
	Console.WriteLine("{0} {1}", result.Item1, result.Item2);
}

private static Tuple<int, int> Compare(List<int> first, List<int> second)
{
	int firstPoints = 0;
	int secondPoints = 0;
	
	for (int i = 0; i < first.Count; i++)
	{
		if(first[i] == second[i])
		{
			continue;
		}
		else if(first[i] > second[i])
		{
			firstPoints ++;
		}
		else
		{
			secondPoints++;
		}
	}
	return new Tuple<int, int>(firstPoints, secondPoints);
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
