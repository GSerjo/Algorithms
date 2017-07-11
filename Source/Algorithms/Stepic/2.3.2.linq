<Query Kind="Program" />

void Main()
{
	var lines = File.ReadAllLines(Path.Combine(Path.GetDirectoryName(Util.CurrentQueryPath), "2.3.2.txt"));
	
	var numbers = lines[0];
	//var numbers = Console.ReadLine();
	
	var processorCount = int.Parse(numbers.Split(' ')[0]);
	
	var items = lines[1].Split(' ').Select(long.Parse).ToList();
	//var items = Console.ReadLine().Split(' ').Select(long.Parse).ToList();
	
	var processors = new MinHeap();
	for (int i = 0; i < processorCount; i++)
	{
		processors.Insert(new Processor { Id = i });
	}
	
	for (int i = 0; i < items.Count; i++)
	{
		var processor = processors.Peak();
		var task = processor.Process(new Task { Time = items[i] });
		processors.Update();
		
		Console.WriteLine($"{task.ProcessorId} {task.Start}");
	}
}

private class Processor
{
	public long Time { get; private set; }
	public int Id { get; set; }
	
	public Task Process(Task task)
	{
		task.ProcessorId = Id;
		task.Start = Time;
		Time += task.Time;
		return task;
	}
}

private class MinHeap
{
	private Processor[] _items = new Processor[2];
	private int _size = 0;

	public void Insert(Processor processor)
	{
		if (_items.Length == _size + 1)
		{
			Resize();
		}
		_items[++_size] = processor;
		Swim(_size);
	}

	public Processor Peak()
	{
		var result = _items[1];
		return result;
	}
	
	public void Update()
	{
		Sink(1);
	}

	private void Sink(int number)
	{
		while (2 * number <= _size)
		{
			int j = 2 * number;
			if (j < _size && Greater(j, j + 1))
			{
				j++;
			}
			if (!Greater(number, j))
			{
				break;
			}
			Swap(number, j);
			number = j;
		}
	}

	private void Swim(int number)
	{
		while (number > 1 && Greater(number / 2, number))
		{
			Swap(number / 2, number);
			number = number / 2;
		}
	}

	private void Swap(int i, int j)
	{
		var dummy = _items[i];
		_items[i] = _items[j];
		_items[j] = dummy;
	}

	private bool Greater(int i, int j)
	{
		if (_items[i].Time == _items[j].Time)
		{
			return _items[i].Id > _items[j].Id;
		}
		
		return _items[i].Time > _items[j].Time;
	}

	private void Resize()
	{
		var dummy = new Processor[_items.Length * 2];
		Array.Copy(_items, dummy, _items.Length);
		_items = dummy;
	}
}

private class Task
{
	public long Time { get; set; }
	public long Start { get; set; }
	public int ProcessorId { get; set; }
}
