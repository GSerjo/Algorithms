<Query Kind="Program" />

//https://www.hackerrank.com/challenges/balanced-parentheses
void Main()
{
	int inputs = int.Parse(Console.ReadLine());
	//int inputs = int.Parse(Input.Line(0));
	var stack = new Stack<char>();
	
	for (int i = 0; i < inputs; i++)
	{
		var line = Console.ReadLine();
		//var line = Input.Line(i + 1);
		
		bool isInvalid = false;
		
		foreach (char symbol in line)
		{
			switch (symbol)
			{
				case '(':
					stack.Push(')');
					break;
				case '{':
					stack.Push('}');
					break;
				case '[':
					stack.Push(']');
					break;
				case ')':
					if(stack.Count == 0 || stack.Pop() != ')')
					{
						isInvalid = true;
					}
					break;
				case '}':
					if (stack.Count == 0 || stack.Pop() != '}')
					{
						isInvalid = true;
					}
					break;
				case ']':
					if (stack.Count == 0 || stack.Pop() != ']')
					{
						isInvalid = true;
					}
					break;
				default:
					continue;
			}
			if(isInvalid)
			{
				break;
			}
		}
		if (isInvalid || stack.Count != 0)
		{
			Console.WriteLine("NO");
		}
		else
		{
			Console.WriteLine("YES");
		}
		stack = new Stack<char>();
	}
}