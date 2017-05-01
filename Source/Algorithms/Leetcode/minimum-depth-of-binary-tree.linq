<Query Kind="Program" />

/*
https://leetcode.com/problems/minimum-depth-of-binary-tree/

Given a binary tree, find its minimum depth.

The minimum depth is the number of nodes along the shortest path from the root node down to the nearest leaf node.

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

	MinDepth(tree).Dump();
}


private static int MinDepth(TreeNode root)
{
	if (root == null)
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