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

private static int GetMinimumDifference(TreeNode root)
{
	if (root == null)
	{
		return 0;
	}
}


private static int GetMinimumDifference(TreeNode node, int[] result)
{
	if (node == null)
	{
		return 0;
	}
	
}

public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}