<Query Kind="Program" />

/*

https://leetcode.com/problems/binary-tree-level-order-traversal/

Given a binary tree, return the level order traversal of its nodes' values. (ie, from left to right, level by level).

For example:
Given binary tree [3,9,20,null,null,15,7],
    3
   / \
  9  20
    /  \
   15   7
return its level order traversal as:
[
  [3],
  [9,20],
  [15,7]
]

*/

void Main()
{
	var tree = new TreeNode(3);
	tree.left = new TreeNode(9);
	tree.left.left = new TreeNode(8);
	tree.right = new TreeNode(20);
	tree.right.right = new TreeNode(7);
	tree.right.left = new TreeNode(15);
	
	LevelOrder(tree).ToString().Dump();
}

private static StringBuilder LevelOrder(TreeNode root)
{
	var byLevel = new List<IList<int>>();
	LevelOrder(root, 0, byLevel);
	var result = new StringBuilder();
	foreach (var level in byLevel)
	{
		result.Append($"[{string.Join(";", level)}]");
	}
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
		result.Add(new List<int>{ node.val });
	}
	else
	{
		result[level].Add(node.val);
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