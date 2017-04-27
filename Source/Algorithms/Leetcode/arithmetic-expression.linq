<Query Kind="Program" />

/* arithmetic expression
	(1+((2+3)*(4*5)))
*/
void Main()
{
	Calc("(1+((2+3)*(4*5)))").Dump();
}

private static int Calc(string text)
{
	if (string.IsNullOrWhiteSpace(text))
	{
		throw new ArgumentException();
	}
	var operators = new Stack<char>();
	var operands = new Stack<int>();

	foreach (var item in text)
	{
		switch (item)
		{
			case '(':
				break;
			case '+':
			case '-':
			case '*':
				operators.Push(item);
				break;
			case ')':
				{
					var operand1 = operands.Pop();
					var operand2 = operands.Pop();
					var op = operators.Pop();
					switch (op)
					{
						case '+':
							operands.Push(operand2 + operand1);
							break;
						case '-':
							operands.Push(operand2 - operand1);
							break;
						case '*':
							operands.Push(operand2 * operand1);
							break;
					}
				}
				break;
			default:
				int value;
				if (int.TryParse(item.ToString(), out value))
				{
					operands.Push(value);
				}
				break;
		}
	}
	return operands.Pop();
}
