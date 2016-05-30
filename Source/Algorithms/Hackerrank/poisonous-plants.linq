<Query Kind="Program" />

// https://www.hackerrank.com/challenges/poisonous-plants

//1 3 5 2 7 6 4 2 1
//0 1 1 2 1 2 3 4 0

void Main()
{

	var inputCount = int.Parse(Console.ReadLine());
//	var inputCount = int.Parse(Input.Line(0));

	var pesticides = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
//	var pesticides = Input.Line(1).Split(' ').Select(x=>int.Parse(x)).ToArray();
	int[] days = new int[inputCount];
	int min = pesticides.First();
	int max = 0;
	var stack = new Stack<int>();
	stack.Push(0);

	for (int i = 1; i < inputCount; i++)
	{
		if (pesticides[i] > pesticides[i - 1])
		{
			days[i] = 1;
		}
		if(pesticides[i] < min)
		{
			min = pesticides[i];
		}
		
		while (stack.Count != 0 && pesticides[stack.Peek()] >= pesticides[i])
		{
			if (pesticides[i] > min && days[stack.Peek()] + 1 > days[i])
			{
				days[i] = days[stack.Peek()] + 1;
			}
			stack.Pop();
		}
		
		if(days[i] > max)
		{
			max = days[i];
		}

		stack.Push(i);
	}
	Console.WriteLine(max);
}
