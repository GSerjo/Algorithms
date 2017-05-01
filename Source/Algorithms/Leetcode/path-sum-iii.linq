<Query Kind="Program" />

/*

https://leetcode.com/problems/path-sum-iii/

You are given a binary tree in which each node contains an integer value.

Find the number of paths that sum to a given value.

The path does not need to start or end at the root or a leaf, but it must go downwards (traveling only from parent nodes to child nodes).

The tree has no more than 1,000 nodes and the values are in the range -1,000,000 to 1,000,000.

Example:

root = [10,5,-3,3,2,null,11,3,-2,null,1], sum = 8

      10
     /  \
    5   -3
   / \    \
  3   2   11
 / \   \
3  -2   1

Return 3. The paths that sum to 8 are:

1.  5 -> 3
2.  5 -> 2 -> 1
3. -3 -> 11

*/

void Main()
{

}

private static int PathSum(TreeNode root, int sum)
{
	if(root == null)
	{
		return 0;
	}
	return PathSumCore(root, sum) + PathSum(root.left, sum) + PathSum(root.right, sum);
}

private static int PathSumCore(TreeNode node, int sum)
{
	if(node == null)
	{
		return 0;
	}
	sum -= node.val;
	if(sum == 0)
	{
		return PathSumCore(node.left, sum) + PathSumCore(node.right, sum) + 1;
	}
	else
	{
		return PathSumCore(node.left, sum) + PathSumCore(node.right, sum);
	}
}



public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}