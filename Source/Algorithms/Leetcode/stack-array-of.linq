<Query Kind="Program" />

// stack-array

void Main()
{
	var stack = new ArrayStackOf<int>(5);
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

private class ArrayStackOf<T>
{
	private int _count = 0;
	private T[] _array;
	
	public ArrayStackOf(int count)
	{
		_array = new T[count];
	}
	
	public bool IsEmpty => _count == 0;
	
	public void Push(T value)
	{
		if(_array.Length == _count)
		{
			throw new IndexOutOfRangeException();
		}
		_array[_count++] = value;
	}
	
	public T Pop()
	{
		if(IsEmpty)
		{
			throw new InvalidOperationException();
		}
		var result = _array[--_count];
		_array[_count] = default(T);
		return result;
	}
}

