<Query Kind="Program" />

/*

Union-Find: Weighted-Quick-Union

*/

void Main()
{
	
}

private class QuickUnion
{
	private int[] _id;
	private int[] _size;
	
	public QuickUnion(int count)
	{
		Count = count;
		_id = new int[count];
		_size = new int[count];
		
		for (int i = 0; i < count; i++)
		{
			_id[i] = i;
			_size[i] = 1;
		}
	}


	

	public int Count { get; private set;}
}
