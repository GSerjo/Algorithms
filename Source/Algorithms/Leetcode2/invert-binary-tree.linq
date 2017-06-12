<Query Kind="Program" />

void Main()
{
	var root = new TreeNode(4);
}

private static TreeNode InvertTree(TreeNode root)
{
	if (root == null)
	{
		return null;
	}
	var queue = new Queue<TreeNode>();
	queue.Enqueue(root);
	while (queue.Count != 0)
	{
		var node = queue.Dequeue();
		if (node == null)
		{
			continue;
		}
		var left = node.left;
		node.left = node.right;
		node.right = left;
		
		queue.Enqueue(node.left);
		queue.Enqueue(node.right);
	}
	return root;
}


public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}
