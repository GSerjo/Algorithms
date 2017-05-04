<Query Kind="Program" />

/*

https://leetcode.com/problems/convert-sorted-array-to-binary-search-tree/

Given an array where elements are sorted in ascending order, convert it to a height balanced BST.

*/

void Main()
{

}

private static TreeNode SortedArrayToBST(int[] nums)
{
	if (nums == null || nums.Length == 0)
	{
		return null;
	}
	return SortedArrayToBST(nums, 0, nums.Length - 1);
}

private static TreeNode SortedArrayToBST(int[] nums, int lo, int hi)
{
	if (lo > hi)
	{
		return null;
	}
	var mid = (lo + hi)/2;
	var node = new TreeNode(nums[mid]);
	node.left = SortedArrayToBST(nums, lo, mid - 1);
	node.right = SortedArrayToBST(nums, mid + 1, hi);
	return node;
}

public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}
