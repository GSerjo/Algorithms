<Query Kind="Program" />

/*

s = "3[a]2[bc]", return "aaabcbc".
s = "3[a2[c]]", return "accaccacc".
s = "2[abc]3[cd]ef", return "abcabccdcdcdef".

*/

void Main()
{
	DecodeString("10[test]").Dump();
}

private static string DecodeString(string s)
{
	if (string.IsNullOrEmpty(s))
	{
		return string.Empty;
	}
	
	var result = new StringBuilder();
	var text = new Stack<string>();
	var number = new Stack<int>();
	var numberStartIndex = -1;
	var counter = 0;
	
	foreach (var item in s)
	{
		if (item == '[')
		{
			var textNumber = s.Substring(numberStartIndex, counter - numberStartIndex);
			number.Push(int.Parse(textNumber));
			text.Push("[");
			numberStartIndex = -1;
		}
		else if (item == ']')
		{
			var dummy = new StringBuilder();
			while (true)
			{
				var temp = text.Pop();
				if (temp == "[")
				{
					break;
				}
				dummy.Insert(0, temp);
			}
			var part = new StringBuilder();
			var count = number.Pop();
			
			part.Insert(0, dummy.ToString(), count);
			if (text.Count == 0)
			{
				result.Append(part);
			}
			else
			{
				text.Push(part.ToString());
			}
		}
		else if (char.IsDigit(item))
		{
			if (numberStartIndex == -1)
			{
				numberStartIndex = counter;
			}
		}
		else
		{
			text.Push(item.ToString());
		}
		counter++;
	}
	var end = new StringBuilder();
	while(text.Count != 0)
	{
		end.Insert(0, text.Pop());
	}
	result.Append(end.ToString());	
	return result.ToString();
}

