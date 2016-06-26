<Query Kind="Program" />

// https://leetcode.com/problems/invert-binary-tree/

/*

FROM
     4
   /   \
  2     7
 / \   / \
1   3 6   9

TO
     4
   /   \
  7     2
 / \   / \
9   6 3   1

*/

void Main()
{
	var root = new TreeNode(4);

	root.left = new TreeNode(2);
	root.left.left = new TreeNode(1);
	root.left.right = new TreeNode(3);

	root.right = new TreeNode(7);
	root.right.left = new TreeNode(6);
	root.right.right = new TreeNode(9);
	
//	var result = InvertTree(root);
	
	var result = InvertTree1(root);
}

private static TreeNode InvertTree(TreeNode root)
{
	if(root == null)
	{
		return null;
	}
	var queue = new Queue<TreeNode>();
	queue.Enqueue(root);
	
	while(queue.Count != 0)
	{
		var node = queue.Dequeue();
		
		if(node == null)
		{
			continue;
		}
		
		var dummy = node.left;
		node.left = node.right;
		node.right = dummy;
		
		queue.Enqueue(node.left);
		queue.Enqueue(node.right);
	}
	
	return root;
}


private static TreeNode InvertTree1(TreeNode root)
{
	InvertTreeHelper(root);
	return root;
}

private static void InvertTreeHelper(TreeNode root)
{
	if(root == null)
	{
		return;
	}

	var dummy = root.left;
	root.left = root.right;
	root.right = dummy;
	
	InvertTreeHelper(root.left);
	InvertTreeHelper(root.right);
}


public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}
