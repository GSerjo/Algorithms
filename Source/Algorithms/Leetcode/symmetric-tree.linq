<Query Kind="Program" />

/*

https://leetcode.com/problems/symmetric-tree/

Given a binary tree, check whether it is a mirror of itself (ie, symmetric around its center).

For example, this binary tree [1,2,2,3,4,4,3] is symmetric:

    1
   / \
  2   2
 / \ / \
3  4 4  3
But the following [1,2,2,null,3,null,3] is not:
    1
   / \
  2   2
   \   \
   3    3

*/

void Main()
{
	var tree = new TreeNode(1);
	tree.left = new TreeNode(2);
	tree.left.left = new TreeNode(3);
	tree.left.right = new TreeNode(4);
	
	tree.right = new TreeNode(2);
	tree.right.right = new TreeNode(3);
	tree.right.left = new TreeNode(4);


	var tree1 = new TreeNode(1);
	tree1.left = new TreeNode(2);
	tree1.left.right = new TreeNode(3);

	tree1.right = new TreeNode(2);
	tree1.right.right = new TreeNode(3);
	
	IsSymmetric(tree).Dump();
	IsSymmetric(tree1).Dump();

	IsSymmetric2(tree).Dump();
	IsSymmetric2(tree1).Dump();
}

private static bool IsSymmetric2(TreeNode root)
{
	if (root == null)
	{
		return true;
	}
	return IsSymmetric(root.left, root.right);
}

private static bool IsSymmetric(TreeNode left, TreeNode right)
{
	if (left == null && right == null)
	{
		return true;
	}
	if (left == null && right != null)
	{
		return false;
	}
	if (right == null && left != null)
	{
		return false;
	}
	if (left.val != right.val)
	{
		return false;
	}
	return IsSymmetric(left.left, right.right) && IsSymmetric(left.right, right.left);
}

private static bool IsSymmetric(TreeNode root)
{
	if (root == null)
	{
		return true;
	}
	
	var queue = new Queue<TreeNode>();
	queue.Enqueue(root.left);
	queue.Enqueue(root.right);
	while (queue.Count != 0)
	{
		var left = queue.Dequeue();
		var right = queue.Dequeue();
		
		if (left == null && right == null)
		{
			continue;
		}
		if (left == null && right != null)
		{
			return false;
		}
		if (right == null && left != null)
		{
			return false;
		}
		if (left.val != right.val)
		{
			return false;
		}

		queue.Enqueue(left.left);
		queue.Enqueue(right.right);

		queue.Enqueue(left.right);
		queue.Enqueue(right.left);
	}
	return true;
}

public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}