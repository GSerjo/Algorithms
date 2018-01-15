<Query Kind="Program" />

void Main()
{
	var root = new TreeNode(1);
	PathSum(root, 1).Dump();
}

public IList<IList<int>> PathSum(TreeNode root, int sum)
{
	if(root == null)
	{
		return new List<IList<int>>();
	}
	var result = new List<IList<int>>();
	PathSum(root, result, sum, string.Empty);
	return result;
}

private void PathSum(TreeNode root, IList<IList<int>> paths, int sum, string path)
{
	if(root == null)
	{
		return;
	}
	sum -= root.val;
	if (string.IsNullOrWhiteSpace(path))
	{
		path = root.val.ToString();
	}
	else
	{
		path += $",{root.val}";
	}
	if (sum == 0 && root.left == null && root.right == null)
	{
		if (path.Contains(','))
		{
			paths.Add(new List<int>(path.Split(',').Select(int.Parse)));
		}
		else
		{
			paths.Add(new List<int> { int.Parse(path) });
		}
	}
	PathSum(root.left, paths, sum, path);
	PathSum(root.right, paths, sum, path);
}

public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}
