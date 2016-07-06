<Query Kind="Program" />

// https://leetcode.com/problems/balanced-binary-tree/

void Main()
{
	
}

private static bool IsBalanced(TreeNode root)
{
	if(root == null)
	{
		return true;
	}
	var left = Depth(root.left);
	var right = Depth(root.right);
	
	return Math.Abs(left - right) <=1 && IsBalanced(root.left) && IsBalanced(root.right);
}

private static int Depth(TreeNode root)
{
	if (root == null)
	{
		return 0;
	}
	
	var left = Depth(root.left);
	var rifht = Depth(root.right);
	return Math.Max(left, rifht) + 1;
}

public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}
