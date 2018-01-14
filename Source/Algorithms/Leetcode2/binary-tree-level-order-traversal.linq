<Query Kind="Program" />

void Main()
{
	
}

public IList<IList<int>> LevelOrder(TreeNode root)
{
	var result = new List<IList<int>>();
	if(root == null)
	{
		return result;
	}
	LevelOrder(root, result, 0);
	return result;
}

public void LevelOrder(TreeNode root, List<IList<int>> levels, int level)
{
	if(root == null)
	{
		return;
	}
	if(levels.Count == level)
	{
		IList<int> values = new List<int> {root.val};
		levels.Add(values);
	}
	else
	{
		levels[level].Add(root.val);
	}
	LevelOrder(root.left, levels, level + 1);
	LevelOrder(root.right, levels, level + 1);
}

public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}
