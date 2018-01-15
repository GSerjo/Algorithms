<Query Kind="Program" />

void Main()
{
	
}

public int SumOfLeftLeaves(TreeNode root)
{
	var result = new[] { 0 };
	SumOfLeftLeaves(root, result, false);
	return result[0];
}

private void SumOfLeftLeaves(TreeNode root, int[] result, bool isLeft)
{
	if(root == null)
	{
		return;
	}
	if(isLeft && root.right == null && root.left == null)
	{
		result[0] += root.val;
	}
	SumOfLeftLeaves(root.left, result, true);
	SumOfLeftLeaves(root.right, result, false);
}

public int SumOfLeftLeaves2(TreeNode root)
{
	var result = 0;

	var stack = new Stack<TreeNode>();
	stack.Push(root);
		
	while (stack.Count != 0)
	{
		var node = stack.Pop();
		if(node == null)
		{
			continue;
		}
		
		if(node.left != null && node.left.left == null && node.left.right == null)
		{
			result += node.left.val;
		}

		stack.Push(node.left);
		stack.Push(node.right);
	}
	return result;
}

public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}
