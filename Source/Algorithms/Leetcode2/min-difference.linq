<Query Kind="Program" />

void Main()
{
	Min(new[] { 1, 3, 15, 11, 2 }, new[] {23, 127, 235,19, 8}).Dump();
}

private int Min(int[] a, int[] b)
{
	Array.Sort(a);
	Array.Sort(b);
	
	var i = 0;
	var j = 0;

	var result = int.MaxValue;
	while (i < a.Length && j < b.Length)
	{
		var dummy = Math.Abs(a[i] - b[j]);
		if (dummy < result)
		{
			result = dummy;
		}
		if (a[i] > b[j])
		{
			j++;
		}
		else if(b[j] > a[i])
		{
			i++;
		}
		else
		{
			break;
		}
	}
	return result;
}
