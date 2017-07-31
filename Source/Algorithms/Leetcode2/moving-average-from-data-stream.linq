<Query Kind="Program" />

void Main()
{
	var t = new MovingAverage(5);
	var data = new List<int> { 12009, 1965, -940, -8516, -16446, 7870, 25545, -21028, 18430, -23464};
	
	foreach (var item in data)
	{
		t.Next(item).Dump();
	}
}

public class MovingAverage
{
	private readonly int _size;
	private double _sum;
	private readonly Queue<int> _queue = new Queue<int>();
	
	public MovingAverage(int size)
	{
		_size = size;
	}

	public double Next(int val)
	{
		if (_queue.Count < _size)
		{
			_queue.Enqueue(val);
			_sum += val;
			return _sum/_queue.Count;
		}
		_sum = _sum - _queue.Dequeue() + val;
		_queue.Enqueue(val);
		return _sum/_size;
	}
}
