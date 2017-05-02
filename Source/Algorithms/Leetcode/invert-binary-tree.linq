<Query Kind="Program" />

/*

https://leetcode.com/problems/invert-binary-tree/

Invert a binary tree.

     4
   /   \
  2     7
 / \   / \
1   3 6   9
to
     4
   /   \
  7     2
 / \   / \
9   6 3   1

*/

void Main()
{
	var tree = new TreeNode(4);
	tree.left = new TreeNode(2);
	tree.right = new TreeNode(7);
	
	var t = InvertTree(tree);
}

private static TreeNode InvertTree(TreeNode root)
{
	if(root == null)
	{
		return null;
	}
	var temp = root.left;
	root.left = root.right;
	root.right = temp;
	
	InvertTree(root.left);
	InvertTree(root.right);
	return root;
}

public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}