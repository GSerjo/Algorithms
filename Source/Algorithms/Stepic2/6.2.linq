<Query Kind="Program" />

private static long _count = 0;

void Main()
{
	//Console.ReadLine();
	
	var list = "2 3 9 2 9".Split(' ').Select(x=>int.Parse(x)).ToArray();
	Count(list);
	
	Console.WriteLine(_count);
}

private static int[] Count(int[] array)
{
	if(array.Length == 1)
	{
		return array;
	}
	var mid = array.Length/2;
	var left = new int[mid];
	var right = new int[array.Length - mid];
	
	Array.Copy(array, 0, left, 0, mid);
	Array.Copy(array, mid, right, 0, array.Length - mid);
	
	left = Count(left);
	right = Count(right);
	
	return Merge(left, right);

}

private static int[] Merge(int[] left, int[] right)
{
	var i = 0;
	var j = 0;
	var result = new int[left.Length + right.Length];
	
	for (int k = 0; k < result.Length; k++)
	{
		if(i >= left.Length)
		{
			result[k] = right[j++];
		}
		else if(j >= right.Length)
		{
			result[k] = left[i++];
		}
		else if(left[i] <= right[j])
		{
			result[k] = left[i++];
		}
		else
		{
			result[k] = right[j++];
			_count += left.Length - i;
		}
	}
	return result;
}

