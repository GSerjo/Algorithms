<Query Kind="Program" />

void Main()
{
	//var word = Console.ReadLine();
	
	var word = "([](){([])})";

	var result = IsValid(word);
	if (result == -1)
	{
		Console.WriteLine("Success");
	}
	else
	{
		Console.WriteLine(result + 1);
	}
}


private static int IsValid(string value)
{
	var stack = new Stack<Item>();
	
	for (int i = 0; i < value.Length; i++)
	{
		if (!IsBracket(value[i]))
		{
			continue;
		}
		if (IsOpen(value[i]))
		{
			stack.Push(new Item { Value = value[i], Index = i});
		}
		else
		{
			if (stack.Count == 0)
			{
				return i;
			}
			switch (value[i])
			{
				case ']':
					if (stack.Pop().Value != '[')
					{
						return i;
					}
					break;
				case ')':
					if (stack.Pop().Value != '(')
					{
						return i;
					}
					break;
				case '}':
					if (stack.Pop().Value != '{')
					{
						return i;
					}
					break;
			}
		}
	}
	if (stack.Count == 0)
	{
		return -1;
	}
	return stack.Last().Index;
}

private static bool IsOpen(char bracket)
{
	return bracket == '[' || bracket == '(' || bracket == '{';
}

private static bool IsBracket(char bracket)
{
	return bracket == '[' || bracket == '(' || bracket == '{' ||
	bracket == ']' || bracket == ')' || bracket == '}';
}

private struct Item
{
	public char Value { get; set; }
	public int Index { get; set; }
}