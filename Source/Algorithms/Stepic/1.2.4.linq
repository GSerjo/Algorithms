<Query Kind="Program" />

void Main()
{
	var lines = File.ReadAllLines(Path.Combine(Path.GetDirectoryName(Util.CurrentQueryPath), "1.2.4.txt"));
	
	var count = int.Parse(lines[0]);
	//var count = int.Parse(Console.ReadLine());
	
	var stack = new StackWithMax();
	for (int i = 0; i < count; i++)
	{
		var command = lines[i+1];
		//var command = Console.ReadLine();

		if (command.Contains("push"))
		{
			var value = int.Parse(command.Split(' ')[1]);
			stack.Push(value);
		}
		else if (command.Contains("max"))
		{
			Console.WriteLine(stack.Max());
		}
		else if (command.Contains("pop"))
		{
			stack.Pop();
		}
	}
}

private class StackWithMax
{
	private Item[] _stack = new Item[2];
	private int _size;
	
	public void Push(int value)
	{
		if (_stack.Length == _size)
		{
			Resize(_size * 2);
		}
		Item item;
		if (_size == 0)
		{
			item = new Item { Value = value, Max = value };
		}
		else
		{
			var max = Math.Max(value, Peak().Max);
			item = new Item { Value = value, Max = max };
		}
		_stack[_size++] = item;
	}
	
	public int Pop()
	{
		var result = _stack[--_size];
		_stack[_size] = null;

		if (_size > 0 && _size == _stack.Length / 4)
		{
			Resize(_stack.Length / 2);
		}
		return result.Value;
	}
	
	public int Max()
	{
		return Peak().Max;
	}
	
	private Item Peak()
	{
		return _stack[_size - 1];
	}
	
	private void Resize(int size)
	{
		var dummy = new Item[size];
		Array.Copy(_stack, dummy, _size);
		_stack = dummy;
	}
}

private class Item
{
	public int Value { get; set; }
	public int Max { get; set; }
}
