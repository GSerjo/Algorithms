<Query Kind="Program" />

/*

Union-Find: Quick-Union

*/

void Main()
{
	var lines = File.ReadLines(Path.Combine(Path.GetDirectoryName(Util.CurrentQueryPath), "tinyUF.txt"));

	var components = int.Parse(lines.First());
	var quickUnion = new QuickUnion(components);

	foreach (var line in lines.Skip(1))
	{
		var values = line.Split(' ').Select(int.Parse).ToArray();

		if (quickUnion.Connected(values[0], values[1]))
		{
			continue;
		}
		quickUnion.Union(values[0], values[1]);
	}

	Console.WriteLine($"Components: {quickUnion.Count}");
}

private class QuickUnion
{
	private int _count;
	private int[] _id;

	public QuickUnion(int count)
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
		var rootP = Root(p);
		var rootQ = Root(q);
		
		if (rootP == rootQ)
		{
			return;
		}
		
		_id[rootP] = rootQ;
		_count--;
	}

	public bool Connected(int p, int q)
	{
		return Root(p) == Root(q);
	}

	public int Count
	{
		get { return _count; }
	}

	private int Root(int i)
	{
		while (i != _id[i])
		{
			i = _id[i];
		}
		return i;
	}
}