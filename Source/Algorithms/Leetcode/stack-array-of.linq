<Query Kind="Program" />

// stack-array

void Main()
{
	var stack = new ArrayStackOf<int>();
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
	private T[] _array = new T[1];
	
	public bool IsEmpty => _count == 0;
	
	public void Push(T value)
	{
		if (_count == _array.Length)
		{
			Resize(2 * _array.Length);
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
		if (_count == _array.Length / 4)
		{
			Resize(_array.Length/2);
		}
		return result;
	}
	
	public T Peek()
	{
		if (IsEmpty)
		{
			throw new InvalidOperationException();
		}
		return _array[_count - 1];
	}
	
	private void Resize(int length)
	{
		var newArray = new T[length];
		for (int i = 0; i < _array.Length; i++)
		{
			newArray[i] = _array[i];
		}
		_array = newArray;
	}
}