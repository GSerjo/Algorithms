<Query Kind="Program" />

void Main()
{
	//var number = int.Parse(Console.ReadLine());
	var number = 10;
	
	var result = Sequence(number);
	
	Console.WriteLine(result.Count - 1);
	Console.WriteLine(string.Join(" ", result));
}

private static Stack<int> Sequence(int value)
{
	var result = new Stack<int>();

	while (true)
	{
		if (value == 1)
		{
			break;
		}
		result.Push(value);

		if (value % 3 == 0)
		{
			value /= 3;
			continue;
		}
		if ((value - 1) % 3 == 0)
		{
			value -= 1;
			continue;
		}
		if (value % 2 == 0)
		{
			value /= 2;
			continue;
		}
		if ((value - 1) % 2 == 0)
		{
			value -= 1;
			continue;
		}
		value -= 1;
	}
	result.Push(1);
	return result;
}