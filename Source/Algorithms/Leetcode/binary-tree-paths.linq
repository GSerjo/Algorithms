<Query Kind="Program" />

/*

https://leetcode.com/problems/binary-tree-paths/

Given a binary tree, return all root-to-leaf paths.

For example, given the following binary tree:

   1
 /   \
2     3
 \
  5
All root-to-leaf paths are:

["1->2->5", "1->3"]

*/

void Main()
{
	var tree = new TreeNode(1);
	tree.left = new TreeNode(2);
	tree.left.right = new TreeNode(5);
	
	tree.right = new TreeNode(3);
	
	BinaryTreePaths(tree).Dump();
}

private static IList<string> BinaryTreePaths(TreeNode root)
{
	if(root == null)
	{
		return new List<string>();
	}
	var result = new List<string>();
	BinaryTreePaths(root, "", result);
	return result;
}


private static void BinaryTreePaths(TreeNode node, string path, List<string> paths)
{
	if(node.left == null && node.right == null)
	{
		path += node.val;
		paths.Add(path);
	}
	
	if(node.left != null)
	{
		BinaryTreePaths(node.left, path + string.Format("{0}->", node.val), paths);
	}
	if (node.right != null)
	{
		BinaryTreePaths(node.right, path + string.Format("{0}->", node.val), paths);
	}
}

public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}