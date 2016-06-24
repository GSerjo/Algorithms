<Query Kind="Program" />

// https://leetcode.com/problems/binary-tree-paths/

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
	
	BinaryTreePaths(root);
	
	_result.Dump();
	
}
private static List<string> _result;

private static IList<string> BinaryTreePaths(TreeNode root)
{
	_result = new List<string>();
	
	if(root == null)
	{
		return new List<string>();
	}
	TreePath(root, root.val.ToString());
	return _result;
}

private static void TreePath(TreeNode node, string path)
{
	if(node == null)
	{
		return;
	}
	var left = path;
	var right = path;
	if(node.left != null)
	{
		left += "->" + node.left.val.ToString();
	}
	if (node.right != null)
	{
		right += "->" + node.right.val.ToString();
	}
	if(node.left == null && node.right == null)
	{
		_result.Add(path);
	}
	TreePath(node.left, left);
	TreePath(node.right, right);
}


public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}

