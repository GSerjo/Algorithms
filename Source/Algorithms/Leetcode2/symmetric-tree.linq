<Query Kind="Program" />

void Main()
{
	
}

private static bool IsSymmetric(TreeNode root)
{
	if (root == null)
	{
		return true;
	}
	return IsSymmetric(root.left, root.right);
}

private static bool IsSymmetric(TreeNode one, TreeNode two)
{
	if (one == null && two == null)
	{
		return true;
	}
	if (one == null || two == null)
	{
		return false;
	}
	if (one.val != two.val)
	{
		return false;
	}
	var value1 = IsSymmetric(one.right, two.left);
	var value2 = IsSymmetric(one.left, two.right);
	if (value1 != true || value2 != true)
	{
		return false;
	}
	return true;
}

public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}