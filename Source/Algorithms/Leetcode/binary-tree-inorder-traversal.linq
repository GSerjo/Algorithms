<Query Kind="Program" />

/*

https://leetcode.com/problems/binary-tree-inorder-traversal

Given a binary tree, return the inorder traversal of its nodes' values.

For example:
Given binary tree [1,null,2,3],
   1
    \
     2
    /
   3
return [1,3,2]

*/

void Main()
{
	var tree = new TreeNode(1);
	tree.right = new TreeNode(2);
	tree.right.left = new TreeNode(3);
	
	InorderTraversal(tree).Dump();
}

private static IList<int> InorderTraversal(TreeNode node)
{
	var result = new List<int>();
	var stack = new Stack<TreeNode>();
	while (stack.Count != 0 || node != null)
	{
		if(node != null)
		{
			stack.Push(node);
			node = node.left;
		}
		else
		{
			node = stack.Pop();
			result.Add(node.val);
			node = node.right;
		}
	}
	return result;
}


public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}