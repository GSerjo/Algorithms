<Query Kind="Program" />

//https://www.hackerrank.com/challenges/maximum-element

void Main()
{
	int inputs = int.Parse(Console.ReadLine());
	//int inputs = int.Parse(Input.Line(0));
	var stack = new Stack<Item>();
	for (int i = 0; i < inputs; i++)
	{
		var line = Console.ReadLine().Split(' ').Select(x=>int.Parse(x)).ToArray();
		//var line = Input.Line(i + 1).Split(' ').Select(x=>int.Parse(x)).ToArray();
		
		switch (line[0])
		{
			case 1:
				if(stack.Count == 0)
				{
					stack.Push(new Item { Max = line[1], Current = line[1]});
				}
				else
				{
					stack.Push(new Item { Max = Math.Max(line[1], stack.Peek().Max), Current = line[1]});
				}
				break;
			case 2:
				if(stack.Count == 0)
				{
					continue;
				}
				stack.Pop();
				break;
			case 3:
				Console.WriteLine(stack.Peek().Max);
				break;
			default:
				continue;
		}
	}
}

struct Item
{
	public int Max { get; set; }
	public int Current { get; set; }
}