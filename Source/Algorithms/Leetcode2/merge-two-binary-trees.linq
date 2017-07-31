<Query Kind="Program" />

void Main()
{
	var t1 = new TreeNode(1);
	t1.right = new TreeNode(2);
	t1.left = new TreeNode(3);
	t1.left.left = new TreeNode(5);
	
	
	var t2 = new TreeNode(2);
	t2.left = new TreeNode(1);
	t2.left.right = new TreeNode(4);
	t2.right = new TreeNode(3);
	t2.right.right = new TreeNode(7);
	
	var result = MergeTrees(t1, t2);
	result.Dump();
	
}

private static TreeNode MergeTrees(TreeNode t1, TreeNode t2)
{
	if (t1 == null && t2 == null)
	{
		return null;
	}
	if (t1 != null && t2 != null)
	{
		var result = new TreeNode(t1.val + t2.val);
		result.left = MergeTrees(t1.left, t2.left);
		result.right = MergeTrees(t1.right, t2.right);
		return result;
	}
	if (t1 == null)
	{
		var result = new TreeNode(t2.val);
		result.left = MergeTrees(t2.left, null);
		result.right = MergeTrees(t2.right, null);
		return result;
	}
	else
	{
		var result = new TreeNode(t1.val);
		result.left = MergeTrees(t1.left, null);
		result.right = MergeTrees(t1.right, null);
		return result;
	}
}

private void Test(TreeNode node)
{
	if (node == null)
	{
		return;
	}
	Console.WriteLine(node.val);
	Test(node.left);
	Test(node.right);
}

public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}
