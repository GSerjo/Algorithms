<Query Kind="Program" />

/*

https://leetcode.com/problems/path-sum/

Given a binary tree and a sum, determine if the tree has a root-to-leaf path such that adding up all the values along the path equals the given sum.

For example:
Given the below binary tree and sum = 22,
              5
             / \
            4   8
           /   / \
          11  13  4
         /  \      \
        7    2      1
return true, as there exist a root-to-leaf path 5->4->11->2 which sum is 22.

*/

void Main()
{

}

private static bool HasPathSum(TreeNode root, int sum)
{
	if(root == null)
	{
		return false;
	}
	sum -= root.val;
	if(root.left == null && root.right == null)
	{
		return sum == 0;
	}

	return HasPathSum(root.left, sum) || HasPathSum(root.right, sum);
}

public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}