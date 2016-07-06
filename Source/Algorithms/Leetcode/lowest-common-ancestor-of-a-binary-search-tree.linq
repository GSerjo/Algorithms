<Query Kind="Program" />

// https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-search-tree/

void Main()
{
	
}

private static TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
{
	if(p.val > root.val && q.val > root.val)
	{
		return LowestCommonAncestor(root.right, p, q);
	}
	if (p.val < root.val && q.val < root.val)
	{
		return LowestCommonAncestor(root.left, p, q);
	}
	return root;
}

public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}
