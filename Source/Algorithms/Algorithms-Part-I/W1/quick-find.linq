<Query Kind="Program" />

/*

Union-Find: Quick-Find

*/

void Main()
{
	var lines = File.ReadLines(Path.Combine(Path.GetDirectoryName (Util.CurrentQueryPath),"tinyUF.txt"));
	
	var components = int.Parse(lines.First());
	var quickFind = new QuickFind(components);
	
	foreach (var line in lines.Skip(1))
	{
		var values = line.Split(' ').Select(int.Parse).ToArray();

		if (quickFind.Connected(values[0], values[1]))
		{
			continue;
		}
		quickFind.Union(values[0], values[1]);
	}

	Console.WriteLine($"Components: {quickFind.Count}");
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
		for (int i = 0; i < _id.Length; i++)
		{
			if (_id[i] == idP)
			{
				_id[i] = idQ;
			}
		}
		_count--;
	}
	
	public bool Connected(int p, int q)
	{
		return Find(p) == Find(q);
	}

	public int Count
	{
		get { return _count; }
	}
	
	private int Find(int p)
	{
		return _id[p];
	}
	
}

