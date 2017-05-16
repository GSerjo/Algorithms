<Query Kind="Program" />

/*

Union-Find: Quick-Find

*/

void Main()
{

}

private class QuickFind
{
	private int _count;
	private int[] _id;
	
	public QuickFind(int count)
	{
		_count = count;	
		_id = new int[count];
		
		for (int i = 0; i < count; i++)
		{
			_id[i] = i;
		}
	}
	
	public void Union(int p, int q)
	{
		var idP = Find(p);
		var idQ = Find(q);
		if (idP == idQ)
		{
			return;
		}
		
	}
	
	public bool Connected(int p, int q)
	{
		return Find(p) == Find(q);
	}

	public int Count
	{
		get { return _count; }
	}
	
	public int Find(int p)
	{
		return _id[p];
	}
	
}

