<Query Kind="Program" />

void Main()
{
	var lines = File.ReadAllLines(Path.Combine(Path.GetDirectoryName(Util.CurrentQueryPath), "1.2.2.txt"));
	
	//var count = int.Parse(lines[0]);
	//var count = int.Parse(Console.ReadLine());
	
	var items = lines[1].Split(' ').Select(int.Parse).ToList();
	//var items = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
	
	var tree = CreateTree(items);  
	Console.WriteLine(Height(tree.Item1, tree.Item2) + 1);
}

private static int Height(int node, Dictionary<int, List<int>> tree)
{
	if (!tree.ContainsKey(node))
	{
		return 0;
	}
	var nodes = tree[node];
	var height = Height(nodes[0], tree);
	for (int i = 1; i < nodes.Count; i++)
	{
		height = Math.Max(height, Height(nodes[i], tree));
	}
	return height + 1;
}

private static Tuple<int, Dictionary<int, List<int>>> CreateTree(List<int> source)
{
	var result = new Dictionary<int, List<int>>();
	var root = -1;
	
	for (int i = 0; i < source.Count; i++)
	{
		var parent = source[i];
		if (parent == -1)
		{
			root = i;
			if (result.ContainsKey(i))
			{
				continue;
			}
			result[i] = new List<int>();
		}
		else
		{
			if (result.ContainsKey(parent))
			{
				result[parent].Add(i);
			}
			else
			{
				result[parent] = new List<int> { i };
			}
		}
	}
	if (root == -1)
	{
		throw new ArgumentException("No root");
	}
	return new Tuple<int, Dictionary<int, List<int>>>(root, result);	
}

