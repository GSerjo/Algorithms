<Query Kind="Program" />

private static long _count = 0;
private static int[] _aux;

void Main()
{
	//Console.ReadLine();

	var list = "2 3 9 2 9".Split(' ').Select(x => int.Parse(x)).ToArray();
	//Count(list);

	_count = 0;
	_aux = new int[list.Length];

	Count(list, 0, list.Length - 1);

	Console.WriteLine(_count);
}

private static void Count(int[] array, int lo, int hi)
{
	if (lo >= hi)
	{
		return;
	}
	var mid = lo + (hi - lo) / 2;
	Count(array, lo, mid);
	Count(array, mid + 1, hi);

	Merge(array, lo, mid, hi);

}

private static void Merge(int[] array, int lo, int mid, int hi)
{
	var i = lo;
	var j = mid + 1;

	for (int k = lo; k <= hi; k++)
	{
		_aux[k] = array[k];
	}

	for (int k = lo; k <= hi; k++)
	{
		if (i > mid)
		{
			array[k] = _aux[j++];
		}
		else if (j > hi)
		{
			array[k] = _aux[i++];
		}
		else if (_aux[i] <= _aux[j])
		{
			array[k] = _aux[i++];
		}
		else
		{
			array[k] = _aux[j++];
			_count += mid - i + 1;
		}
	}
}
