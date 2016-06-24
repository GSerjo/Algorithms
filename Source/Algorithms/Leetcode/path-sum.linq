<Query Kind="Program" />

// https://leetcode.com/problems/path-sum/

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
	
	HasPathSum(root, 22).Dump();
}

private static bool HasPathSum(TreeNode root, int sum)
{
	if(root == null)
	{
		return false;
	}
	
	if(root.left == null && root.right == null)
	{
		return root.val == sum;
	}
	
	sum = sum - root.val;
	return HasPathSum(root.left, sum) || HasPathSum(root.right, sum);
}


public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}

