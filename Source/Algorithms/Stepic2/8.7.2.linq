<Query Kind="Program" />

void Main()
{
	//var number = int.Parse(Console.ReadLine());
	var number = 96234;
	
	var result = Sequence(number);
	
	//Console.WriteLine(result.Count - 1);
	Console.WriteLine(string.Join(" ", result));
}

private Dictionary<int, int> _cache = new Dictionary<int, int>();

private int Sequence(int value)
{
	var count = Count(value);
	if (count.HasValue)
	{
		return count.Value;
	}
	
	if (value == 1)
	{
		return 0;
	}
	if (value % 3 == 0)
	{
		var result = Sequence(value/3) + 1;
		UpdateCache(value, result);
	}
	if ((value - 1) % 3 == 0)
	{
		var result = Sequence(value - 1) + 1;
		UpdateCache(value, result);
	}
	if (value % 2 == 0)
	{
		var result = Sequence(value / 2) + 1;
		UpdateCache(value, result);
	}
	return Sequence(value - 1) + 1;
}

private int? Count(int key)
{
	if (_cache.ContainsKey(key))
	{
		return _cache[key];
	}
	return null;
}

private void UpdateCache(int key, int value)
{
	if (_cache.ContainsKey(key))
	{
		_cache[key] = Math.Min(_cache[key], value);
	}
	else
	{
		_cache[key] = value;
	}
}