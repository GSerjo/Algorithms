<Query Kind="Program" />

/*
https://leetcode.com/problems/same-tree/

Given two binary trees, write a function to check if they are equal or not.

Two binary trees are considered equal if they are structurally identical and the nodes have the same value.

*/

void Main()
{
	var tree = new TreeNode(4);
	tree.left = new TreeNode(2);
	tree.right = new TreeNode(7);
	
	IsSameTree(tree, tree).Dump();
}

private static bool IsSameTree(TreeNode p, TreeNode q)
{
	if(p == null || q == null)
	{
		return p == q;
	}
	if(p.val != q.val)
	{
		return false;
	}
	return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
}

public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}