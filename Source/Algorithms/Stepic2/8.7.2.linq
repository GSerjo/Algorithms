<Query Kind="Program" />

void Main()
{
	//var number = int.Parse(Console.ReadLine());
	var number = 5;
	
	var result = Sequence(number);
	
	Console.WriteLine(result.Count - 1);
	Console.WriteLine(string.Join(" ", result));
}



private static List<int> Sequence(int target)
{
	if (target == 1)
	{
		return new List<int> {1};
	}

	var cache = new Dictionary<int, int>{{target, 0}};
	
	for (int i = target - 1; i > 0; i--)
	{
		int x1 = int.MaxValue;
		int x2 = int.MaxValue;
		int x3 = int.MaxValue;

		var i3 = i * 3;
		
		if (i3 <= target)
		{
			if (i3 == target)
			{
				cache[i] = 1;
				continue;
			}
			else
			{
				x3 = cache[i3];
			}
		}
		
		var i2 = i*2;

		if (i2 <= target)
		{
			if (i2 == target)
			{
				cache[i] = 1;
				continue;
			}
			else
			{
				x2 = cache[i2];
			}
		}

		var i1 = i + 1;
		if (i1 <= target)
		{
			if (i1 == target)
			{
				cache[i] = 1;
				continue;
			}
			else
			{
				x1 = cache[i1];
			}
		}
		var minDummy = Math.Min(x1, x2);
		var min = Math.Min(minDummy, x3);
		
		cache[i] = min + 1;
	}
	var result = RestoreSequence(cache, target);
	return result;
}

private static List<int> RestoreSequence(Dictionary<int, int> cache, int target)
{
	var value = 1;
	var result = new List<int>();
	
	while (true)
	{
		int x1 = int.MaxValue;
		int x2 = int.MaxValue;
		int x3 = int.MaxValue;

		result.Add(value);

		if (value == target)
		{
			break;
		}
		
		var i1 = value + 1;
		var i2 = value * 2;
		var i3 = value * 3;
		
		x1 = cache[i1];
		
		if(i2 <= target)
			x2 = cache[i2];
			
		if(i3 <= target)
			x3 = cache[i3];


		var minDummy = Math.Min(x1, x2);
		if (minDummy > x3)
			value = i3;
		else
		{
			if (x1 < x2)
				value = i1;
			else
				value = i2;
		}
	}
	return result;
}


