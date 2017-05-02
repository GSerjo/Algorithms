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