<Query Kind="Program" />

/*

https://leetcode.com/problems/binary-tree-tilt

Given a binary tree, return the tilt of the whole tree.

The tilt of a tree node is defined as the absolute difference between the sum of all left subtree node values and the sum of all right subtree node values.
Null node has tilt 0.

The tilt of the whole tree is defined as the sum of all nodes' tilt.

Example:
Input: 
         1
       /   \
      2     3
Output: 1
Explanation: 
Tilt of node 2 : 0
Tilt of node 3 : 0
Tilt of node 1 : |2-3| = 1
Tilt of binary tree : 0 + 0 + 1 = 1

*/

void Main()
{
	var tree = new TreeNode(4);
	
	tree.left = new TreeNode(2);
	tree.left.left = new TreeNode(1);
	tree.left.right = new TreeNode(3);

	tree.right = new TreeNode(7);
	tree.right.right = new TreeNode(8);
	tree.right.left = new TreeNode(5);
	
	FindTilt(tree).Dump();

}

private static int FindTilt(TreeNode root)
{
	if(root == null)
	{
		return 0;
	}
	var result = new int[1];
	FindTilt(root, result);
	return result[0];
}

private static int FindTilt(TreeNode root, int[] result)
{
	if (root == null)
	{
		return 0;
	}
	var left = FindTilt(root.left, result);
	var right = FindTilt(root.right, result);
	result[0] += Math.Abs(left - right);
	return left + right + root.val;;
}

public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}