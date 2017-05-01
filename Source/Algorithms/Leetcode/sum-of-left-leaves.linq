<Query Kind="Program" />

/*

https://leetcode.com/problems/sum-of-left-leaves/

Find the sum of all left leaves in a given binary tree.

Example:

    3
   / \
  9  20
    /  \
   15   7

There are two left leaves in the binary tree, with values 9 and 15 respectively. Return 24.

*/

void Main()
{
	var tree = new TreeNode(3);
	tree.left = new TreeNode(9);
	tree.right = new TreeNode(20);
	tree.right.right = new TreeNode(7);
	tree.right.left = new TreeNode(15);
	
	SumOfLeftLeaves(tree).Dump();
	SumOfLeftLeaves2(tree).Dump();
}

private static int SumOfLeftLeaves2(TreeNode root)
{
	if (root == null)
	{
		return 0;
	}
	var result = 0;
	var queue = new Queue<TreeNode>();
	queue.Enqueue(root);
	while (queue.Count != 0)
	{
		var node = queue.Dequeue();
		if (node.left != null && node.left.left == null && node.left.right == null)
		{
			result += node.left.val;
		}
		if (node.left != null)
		{
			queue.Enqueue(node.left);
		}
		if (node.right != null)
		{
			queue.Enqueue(node.right);
		}
	}
	return result;
}

private static int SumOfLeftLeaves(TreeNode root)
{
	var result = new int[1] { 0 };
	SumOfLeftLeaves(root, false, result);
	return result[0];
}

private static void SumOfLeftLeaves(TreeNode node, bool isLeft, int[] result)
{
	if (node == null)
	{
		return;
	}
	if (node.left == null && node.right == null && isLeft)
	{
		result[0] += node.val;
	}
	SumOfLeftLeaves(node.left, true, result);
	SumOfLeftLeaves(node.right, false, result);
}


public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}