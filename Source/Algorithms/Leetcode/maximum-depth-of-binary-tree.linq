<Query Kind="Program" />

/*
https://leetcode.com/problems/maximum-depth-of-binary-tree/

Given a binary tree, find its maximum depth.

The maximum depth is the number of nodes along the longest path from the root node down to the farthest leaf node.

   1
 /   \
2     3
 \
  5

*/

void Main()
{
	var tree = new TreeNode(1);
	tree.left = new TreeNode(2);
	tree.left.right = new TreeNode(5);

	tree.right = new TreeNode(3);
	
	MaxDepth(tree).Dump();
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