<Query Kind="Program" />

void Main()
{
	
}

public int MinDepth(TreeNode root)
{
	if(root == null)
	{
		return 0;
	}
	var left = MinDepth(root.left);
	var right = MinDepth(root.right);
	if(left == 0 || right == 0)
	{
		return left + right + 1;
	}
	return Math.Min(left, right) + 1;
}

public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}