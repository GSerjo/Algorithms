<Query Kind="Program" />

/*

Print 123 vertically

1
2
3

*/

void Main()
{
	PrintVertically(123);
}

private static void PrintVertically(int value)
{
	var stack = new Stack<int>();

	if (value == 0)
	{
		stack.Push(0);
	}
	while (value != 0)
	{
		var digit = value % 10;
		stack.Push(digit);
		value = value / 10;
	}
	foreach (var item in stack)
	{
		Console.WriteLine(item);
	}
}
