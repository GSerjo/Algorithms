<Query Kind="Program" />

void Main()
{
	
}

public TreeNode InvertTree(TreeNode root)
{	
	var queue = new Queue<TreeNode>();
	queue.Enqueue(root);
	while(queue.Count != 0)
	{
		var node = queue.Dequeue();
		if(node == null)
		{
			continue;
		}
		var temp = node.left;
		node.left = node.right;
		node.right = temp;
		
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
