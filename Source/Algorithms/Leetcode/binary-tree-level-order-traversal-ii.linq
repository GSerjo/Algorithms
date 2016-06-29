<Query Kind="Program" />

// https://leetcode.com/problems/binary-tree-level-order-traversal-ii/
/*
   3
   / \
  9  20
    /  \
   15   7

result
   
[
  [15,7],
  [9,20],
  [3]
]
*/

void Main()
{
	var root = new TreeNode(3);
	root.left = new TreeNode(9);
	root.right = new TreeNode(20);

	root.right.left = new TreeNode(15);
	root.right.right = new TreeNode(7);

	LevelOrder(root).Dump();

}

private static IList<IList<int>> _result = new List<IList<int>>();

private static IList<IList<int>> LevelOrder(TreeNode root)
{
	_result = new List<IList<int>>();
	if (root == null)
	{
		return new List<IList<int>>();
	}
	LevelOrder(root, 0);
	return _result;
}

private static void LevelOrder(TreeNode root, int level)
{
	if (root == null)
	{
		return;
	}
	AddNode(root.val, level);
	LevelOrder(root.left, level + 1);
	LevelOrder(root.right, level + 1);
}

private static void AddNode(int value, int level)
{
	if (_result.Count <= level)
	{
		_result.Insert(0, new List<int> { value });
	}
	else
	{
		_result[_result.Count - 1 - level].Add(value);
	}
}

public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}