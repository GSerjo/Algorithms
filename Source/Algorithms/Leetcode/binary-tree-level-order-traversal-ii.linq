<Query Kind="Program" />

/*

https://leetcode.com/problems/binary-tree-level-order-traversal-ii/

Given a binary tree, return the bottom-up level order traversal of its nodes' values. (ie, from left to right, level by level from leaf to root).

For example:
Given binary tree [3,9,20,null,null,15,7],
    3
   / \
  9  20
    /  \
   15   7
return its bottom-up level order traversal as:
[
  [15,7],
  [9,20],
  [3]
]

*/

void Main()
{
	var tree = new TreeNode(3);
	tree.left = new TreeNode(9);
	tree.right = new TreeNode(20);
	tree.right.right = new TreeNode(7);
	tree.right.left = new TreeNode(15);

	LevelOrder(tree).Dump();
}

private static IList<IList<int>> LevelOrder(TreeNode root)
{
	var result = new List<IList<int>>();
	LevelOrder(root, 0, result);
	return result;
}

private static void LevelOrder(TreeNode node, int level, List<IList<int>> result)
{
	if (node == null)
	{
		return;
	}
	if (level >= result.Count)
	{
		result.Insert(0, new List<int> { node.val });
	}
	else
	{
		result[result.Count - level - 1].Add(node.val);
	}
	LevelOrder(node.left, level + 1, result);
	LevelOrder(node.right, level + 1, result);
}

public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}