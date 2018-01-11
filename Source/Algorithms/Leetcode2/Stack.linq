<Query Kind="Program" />

void Main()
{
	var stack = new Stack<int>();
	stack.Push(1);
	stack.Push(2);
	stack.Push(3);
	stack.Count.Dump();
	
	stack.Pop().Dump();
	stack.Pop().Dump();
	stack.Count.Dump();
}


public class Stack<T>
{
	
	private Node _head;
	private int _count;
	
	public int Count
	{
		get { return _count;}
	}
	
	public void Push(T value)
	{
		var node = new Node { Value = value, Next = _head};
		_head = node;
		_count++;
	}
	
	public T Pop()
	{
		if(_head == null)
		{
			throw new InvalidOperationException();
		}
		var result = _head.Value;
		_head = _head.Next;
		_count--;
		return result;
	}
	
	class Node
	{
		public T Value;
		public Node Next;
	}
}

