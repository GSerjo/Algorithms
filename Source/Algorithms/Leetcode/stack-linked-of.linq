<Query Kind="Program" />

// Linked stack
void Main()
{
	var stack = new LinkedStackOf<int>();
	stack.IsEmpty.Dump();

	stack.Push(0);
	stack.Push(1);
	stack.Push(2);

	stack.IsEmpty.Dump();

	stack.Pop().Dump();
	stack.Pop().Dump();
	stack.Pop().Dump();

	stack.IsEmpty.Dump();
}

private class LinkedStackOf<T>
{
	private class Node
	{
		public T Value;
		public Node Next;
	}
	
	private Node _head;
	private int _count = 0;
	
	public bool IsEmpty => _count == 0;
	
	public void Push(T value)
	{
		var temp = _head;
		_head = new Node { Next = temp, Value = value };
		_count++;
	}

	public T Peek()
	{
		if (IsEmpty)
		{
			throw new InvalidOperationException();
		}
		return _head.Value;
	}

		public T Pop()
	{
		if (IsEmpty)
		{
			throw new InvalidOperationException();
		}
		var result = _head.Value;
		_head = _head.Next;
		_count--;
		return result;
	}
}