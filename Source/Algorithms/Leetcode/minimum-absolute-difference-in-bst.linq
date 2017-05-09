<Query Kind="Program" />

/*
https://leetcode.com/problems/minimum-absolute-difference-in-bst/

Given a binary search tree with non-negative values, find the minimum absolute difference between values of any two nodes.

Example:

Input:

   1
    \
     3
    /
   2

Output:
1

Explanation:
The minimum absolute difference is 1, which is the difference between 2 and 1 (or between 2 and 3).
Note: There are at least two nodes in this BST.

*/

void Main()
{

}


public static int GetMinimumDifference(TreeNode node)
{
	if (node == null)
	{
		return 0;
	}
	return GetMinimumDifference(node, new int?[] {int.MaxValue, null});
}

public static int GetMinimumDifference(TreeNode node, int?[] result)
{
	if (node == null)
	{
		return result[0].Value;
	}
	GetMinimumDifference(node.left, result);

	if (result[1].HasValue)
	{
		result[0] = Math.Min(result[0].Value, node.val - result[1].Value);
	}
	
	result[1] = node.val;
	GetMinimumDifference(node.right, result);
	return result[0].Value;
}


public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}