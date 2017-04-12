<Query Kind="Program" />

/*
https://leetcode.com/problems/valid-parentheses/

Given a string containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
The brackets must close in the correct order, "()" and "()[]{}" are all valid but "(]" and "([)]" are not.

*/

void Main()
{
	IsValid("()[]{}").Dump();
	IsValid("(]").Dump();
}

private static bool IsValid(string word)
{
	if (string.IsNullOrWhiteSpace(word))
	{
		return false;
	}
	if (word.Length % 2 != 0)
	{
		return false;
	}
	var stack = new Stack<char>();
	foreach (var item in word)
	{
		switch (item)
		{
			case ')':
				{
					if (stack.Count == 0 || stack.Pop() != '(')
					{
						return false;
					}
					break;
				}
			case '}':
				{
					if (stack.Count == 0 || stack.Pop() != '{')
					{
						return false;
					}
					break;
				}
			case ']':
				{
					if (stack.Count == 0 || stack.Pop() != '[')
					{
						return false;
					}
					break;
				}
			default:
				stack.Push(item);
				break;
		}
	}
	return stack.Count == 0;
}
