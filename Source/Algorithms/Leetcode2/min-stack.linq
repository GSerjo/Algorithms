<Query Kind="Program" />

void Main()
{
	var stack = new MinStack();
	stack.Push(-2);
	stack.Push(0);
	stack.Push(-3);
	stack.GetMin().Dump();
	stack.Pop();
	stack.Top().Dump();
	stack.GetMin().Dump();
}

public class MinStack {

	private Stack<int> _data = new Stack<int>();
	private Stack<int> _min = new Stack<int>();

	public MinStack()
	{

	}

	public void Push(int x)
	{
		_data.Push(x);
		if (_min.Count == 0)
		{
			_min.Push(x);
		}
		else
		{
			var dummy = Math.Min(_min.Peek(), x);
			_min.Push(dummy);
		}
	}

	public void Pop()
	{
		_data.Pop();
		_min.Pop();
	}

	public int Top()
	{
		return _data.Peek();
	}

	public int GetMin()
	{
		return _min.Peek();
	}
}
