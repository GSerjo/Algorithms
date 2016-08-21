<Query Kind="Program" />

//https://leetcode.com/problems/invert-binary-tree/

/*
Invert a binary tree.

     4
   /   \
  2     7
 / \   / \
1   3 6   9
to
     4
   /   \
  7     2
 / \   / \
9   6 3   1

*/

void Main()
{
	
}

private static TreeNode InvertTree(TreeNode root)
{
	if(root == null)
	{
		return root;	
	}
	
	var queue = new Queue<TreeNode>();
	queue.Enqueue(root);
	
	while (queue.Count != 0)
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
