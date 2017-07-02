<Query Kind="Program" />

void Main()
{
	
	var lines = File.ReadAllLines(Path.Combine(Path.GetDirectoryName(Util.CurrentQueryPath), "4.3.txt"));
	var count = int.Parse(lines.First());
	//var count = int.Parse(Console.ReadLine());
	
	var heap = new MaxHeap();
	for (int i = 0; i < count; i++)
	{
		var line = lines[i + 1];
		//var line = Console.ReadLine();
		
		var items = line.Split(' ');
		if(items.Length == 2)
		{
			heap.Insert(long.Parse(items[1].Trim()));
		}
		else
		{
			Console.WriteLine(heap.ExtractMax());
		}
	}
}

private class MaxHeap
{
	private long[] _items = new long[2];
	private int _size;
	
	public void Insert(long value)
	{
		if(_items.Length == _size + 1)
		{
			Resize();
		}
		_items[++_size] = value;
		Swim(_size);
	}
	
	public long ExtractMax()
	{
		var result = _items[1];
		Swap(1, _size--);
		_items[_size + 1] = 0;
		Sink(1);
		return result;
	}
	
	private void Sink(int number)
	{
		while(number * 2 <= _size)
		{
			var k = number * 2;
			if(k < _size && Less(k, k + 1))
			{
				k++;
			}
			if(!Less(number, k))
			{
				break;
			}
			Swap(number, k);
			number = k;
		}
	}
	
	private void Swim(int number)
	{
		while(number > 1 && Less(number/2, number))
		{
			Swap(number/2, number);
			number = number/2;
		}
	}
	
	private bool Less(int i, int j)
	{
		return _items[i] < _items[j];
	}
	
	private void Swap(int i, int j)
	{
		var dummy = _items[i];
		_items[i] = _items[j];
		_items[j] = dummy;
	}
	
	private void Resize()
	{
		var dummy = new long[_items.Length * 2];
		Array.Copy(_items, dummy, _items.Length);
		_items = dummy;
	}
}

