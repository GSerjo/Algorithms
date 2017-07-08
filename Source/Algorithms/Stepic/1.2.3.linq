<Query Kind="Program" />

void Main()
{
	var lines = File.ReadAllLines(Path.Combine(Path.GetDirectoryName(Util.CurrentQueryPath), "1.2.3.txt"));
	
	var numbers = lines[0].Split(' ');
	//var numbers = Console.ReadLine().Split(' ');
	
	var size = int.Parse(numbers[0]);
	var count = int.Parse(numbers[1]);
	
	var emulator = new Emulator(size);
	
	for (int i = 0; i < count; i++)
	{
		var line = lines[i+1];
		//var line = Console.ReadLine();
		
		var item = new Item(line);
		emulator.Process(item);
	}
	
	emulator.Finish();
}

private class Emulator
{
	private Queue<Item> _queue = new Queue<Item>();
	private int _size;
	private int _time;
	private int _currentSize;
	
	public Emulator(int size)
	{
		_size = size;
		_time = 0;
	}

	public void Process(Item item)
	{
		if (_size == 0)
		{
			return;
		}

		while (true)
		{
			if (_queue.Count == 0)
			{
				break;
			}
			var first = _queue.Peek();
			if (first.End <= item.Arrival)
			{
				var start = _queue.Dequeue().Start;
				PrintTime(start);
				if (start != -1)
				{
					_currentSize--;
				}
			}
			else
			{
				break;
			}
		}
		if (_currentSize < _size)
		{
			if (item.Arrival >= _time)
			{
				item.Start = item.Arrival;
			}
			else
			{
				item.Start = _time;
			}
			item.End = item.Start + item.Duration;
			
			_queue.Enqueue(item);
			_currentSize++;
			
			_time = item.End;
		}
		else
		{
			item.Start = -1;
			_queue.Enqueue(item);
		}
	}
	
	public void Finish()
	{
		while (_queue.Count != 0)
		{
			PrintTime(_queue.Dequeue().Start);
		}
	}
	
	private void PrintTime(int time)
	{
		Console.WriteLine(time);
	}
}

private class Item
{
	public Item(string data)
	{
		var source = data.Split(' ');
		Arrival = int.Parse(source[0]);
		Duration = int.Parse(source[1]);
	}
	
	public int Start { get; set; }
	public int End { get; set; }
	public int Arrival { get; set; }
	public int Duration { get; set;}
}
