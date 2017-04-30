<Query Kind="Program" />

/*

tree-traversal

*/

void Main()
{
	var tree = new TreeNode(5);
	tree.right = new TreeNode(7);
	tree.right.right = new TreeNode(8);
	tree.right.left = new TreeNode(6);
	
	tree.left = new TreeNode(3);
	tree.left.left = new TreeNode(2);
	tree.left.right = new TreeNode(4);
	
	InOrder(tree);
	Console.WriteLine(Environment.NewLine);	
	PreOrder(tree);
	Console.WriteLine(Environment.NewLine);	
	PostOrder(tree);
}

// 2 3 4 5 6 7 8
private static void InOrder(TreeNode node)
{
	if(node == null)
	{
		return;
	}
	InOrder(node.left);
	Console.WriteLine(node.val);
	InOrder(node.right);
}

// 5 3 2 4 7 6 8
private static void PreOrder(TreeNode node)
{
	if (node == null)
	{
		return;
	}
	Console.WriteLine(node.val);
	PreOrder(node.left);
	PreOrder(node.right);
}

// 2 4 3 6 8 7 5
private static void PostOrder(TreeNode node)
{
	if (node == null)
	{
		return;
	}
	PostOrder(node.left);
	PostOrder(node.right);
	Console.WriteLine(node.val);
}

public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}