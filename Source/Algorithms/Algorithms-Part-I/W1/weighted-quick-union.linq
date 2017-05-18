<Query Kind="Program" />

/*

Union-Find: Weighted-Quick-Union

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
	
	public int Count { get; private set; }
	
	public bool Connected(int p, int q)
	{
		return Root(p) == Root(q);
	}
	
	public void Union(int p, int q)
	{
		int rootP = Root(p);
		int rootQ = Root(q);
		if (rootP == rootQ)
		{
			return;
		}
		if (_size[rootP] > _size[rootQ])
		{
			_id[rootQ] = rootP;
			_size[rootP] += _size[rootQ];
		}
		else
		{
			_id[rootP] = rootQ;
			_size[rootQ] += _size[rootP];
		}
		Count--;
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
