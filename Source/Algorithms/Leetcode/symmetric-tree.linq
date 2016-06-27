<Query Kind="Program" />

// https://leetcode.com/problems/symmetric-tree/

/*

TRUE
    1
   / \
  2   2
 / \ / \
3  4 4  3

FALSE
    1
   / \
  2   2
   \   \
   3    3

*/

void Main()
{
	
}

private static bool IsSymmetric(TreeNode root)
{
	if(root == null)
	{
		return true;
	}
	return IsSymmetric(root.left, root.right);
}

private static bool IsSymmetric(TreeNode left, TreeNode right)
{
	if(left == null && right == null)
	{
		return true;
	}
	if(left == null || right == null)
	{
		return false;
	}
	if(left.val != right.val)
	{
		return false;
	}
	return IsSymmetric(left.left, right.right) && IsSymmetric(left.right, right.left);
}

public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}
