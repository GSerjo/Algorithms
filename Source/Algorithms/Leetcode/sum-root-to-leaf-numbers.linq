<Query Kind="Program" />

// https://leetcode.com/problems/sum-root-to-leaf-numbers/

void Main()
{
	
}


private static int SumNumbers(TreeNode root)
{
	return SumNumbers(root, 0);
}

private static int SumNumbers(TreeNode root, int sum)
{
	if(root == null)
	{
		return 0;
	}
	sum = sum * 10 + root.val;
	if(root.left == null && root.right == null)
	{
		return sum;
	}
	return SumNumbers(root.left, sum) + SumNumbers(root.right, sum);
}

public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}

