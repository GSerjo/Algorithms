<Query Kind="Program" />

void Main()
{
	
}

public int MaxDepth(TreeNode root)
{
	if(root == null)
	{
		return 0;
	}
	return Math.Max(MaxDepth(root.left), MaxDepth(root.right)) + 1;
}

public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}
