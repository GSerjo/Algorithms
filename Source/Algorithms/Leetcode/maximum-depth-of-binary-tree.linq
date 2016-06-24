<Query Kind="Program" />

// https://leetcode.com/problems/maximum-depth-of-binary-tree/

void Main()
{
	var root = new TreeNode(5);
	root.left = new TreeNode(4);
	root.right = new TreeNode(8);

	root.left.left = new TreeNode(11);
	root.left.left.left = new TreeNode(7);
	root.left.left.right = new TreeNode(2);

	root.right.left = new TreeNode(13);
	root.right.right = new TreeNode(4);
	root.right.right.right = new TreeNode(1);
	
	MaxDepth(root).Dump();
}

private static int MaxDepth(TreeNode root)
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
