<Query Kind="Program" />

// https://leetcode.com/problems/valid-parentheses/

void Main()
{
	IsValid("(){()}").Dump();
}


private static bool IsValid(string line)
{
	var stack = new Stack<char>();
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
				if (stack.Count == 0 || stack.Pop() != ')')
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
		if (isInvalid)
		{
			break;
		}
	}
	if (isInvalid || stack.Count != 0)
	{
		return false;
	}
	else
	{
		return true;
	}
}