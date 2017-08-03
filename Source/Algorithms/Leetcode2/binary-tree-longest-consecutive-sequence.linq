<Query Kind="Program" />

void Main()
{
	var root = new TreeNode(1);
	root.right = new TreeNode(3);
	root.right.right = new TreeNode(4);
	root.right.right.right = new TreeNode(5);
	
	root.left = new TreeNode(2);
	
	LongestConsecutive(root).Dump();
}

private int LongestConsecutive(TreeNode root)
{
	if (root == null)
	{
		return 0;
	}
	var result = new int[1];
	LongestConsecutive(root, 0, root.val, result);
	return result[0];
}


private void LongestConsecutive(TreeNode root, int current, int target, int[] result)
{
	if (root == null)
	{
		return;
	}
	if (root.val == target)
	{
		current++;
		result[0] = Math.Max(current, result[0]);
	}
	else
	{
		current = 1;
	}
	LongestConsecutive(root.left, current, root.val + 1, result);
	LongestConsecutive(root.right, current, root.val + 1, result);
}



public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}
