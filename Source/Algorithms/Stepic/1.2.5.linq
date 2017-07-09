<Query Kind="Program" />

void Main()
{
	var lines = File.ReadAllLines(Path.Combine(Path.GetDirectoryName(Util.CurrentQueryPath), "1.2.5.txt"));
	
	//Console.ReadLine();
	
	var items = lines[1].Split(' ').Select(int.Parse).ToList();
	//var items = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
	
	var window = int.Parse(lines[2]);
	//var window = int.Parse(Console.ReadLine());
	
	var queue = new QueueWithMax();
	for (int i = 0; i < items.Count; i++)
	{
		if (i < window)
		{
			queue.Enqueue(items[i]);
		}
		else
		{
			Console.WriteLine(queue.Max());
			queue.Dequeue();
			queue.Enqueue(items[i]);
		}
	}
	Console.WriteLine(queue.Max());
}


private class QueueWithMax
{
	private StackWithMax _stack1 = new StackWithMax();
	private StackWithMax _stack2 = new StackWithMax();
	
	public void Enqueue(int value)
	{
		_stack1.Push(value);
	}
	
	public int Dequeue()
	{
		if (_stack2.IsEmpty)
		{
			while (!_stack1.IsEmpty)
			{
				_stack2.Push(_stack1.Pop());
			}
		}
		return _stack2.Pop();
	}
	
	public int Max()
	{
		var value1 = 0;
		var value2 = 0;

		if (!_stack1.IsEmpty)
		{
			value1 = _stack1.Max();
		}
		if (!_stack2.IsEmpty)
		{
			value2 = _stack2.Max();
		}
		
		return Math.Max(value1, value2);
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

	public bool IsEmpty
	{
		get { return _size == 0; }
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
