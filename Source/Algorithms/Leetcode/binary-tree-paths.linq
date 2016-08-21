<Query Kind="Program" />

//https://leetcode.com/problems/binary-tree-paths/

/*

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
	var root = new TreeNode(1);
	root.left = new TreeNode(2);
	root.left.right= new TreeNode(5);
	
	root.right = new TreeNode(3);
	
	BinaryTreePaths(root).Dump();
}


private static IList<string> BinaryTreePaths(TreeNode root)
{
	if(root == null)
	{
		return new List<string>();
	}
	var result = new List<string>();
	Traverse(root, string.Empty, result);
	return result;
}

private static void Traverse(TreeNode root, string path, List<string> result)
{
	if(root == null)
	{
		return;
	}
	if(root.left != null || root.right != null)
	{
		path = UpdatePath(path, root);
	}
	if(root.left == null && root.right == null)
	{
		result.Add(UpdatePath(path, root));
		return;
	}
	Traverse(root.left, path, result);
	Traverse(root.right, path, result);
}

private static string UpdatePath(string path, TreeNode root)
{
	if (string.IsNullOrWhiteSpace(path))
	{
		path = root.val.ToString();
	}
	else
	{
		path += "->" + root.val;
	}
	return path;
}


public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}

