<Query Kind="Program" />

void Main()
{
	
}

public bool IsSameTree(TreeNode p, TreeNode q)
{
	if(p == null && q != null)
	{
		return false;
	}
	if(p != null && q == null)
	{
		return false;
	}
	if(p == null && q == null)
	{
		return true;
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
