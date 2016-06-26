<Query Kind="Program" />

// https://leetcode.com/problems/same-tree/

void Main()
{
	
}


private static bool IsSameTree(TreeNode p, TreeNode q)
{
	if(p == null && q == null)
	{
		return true;
	}
	if(p == null || q == null)
	{
		return false;
	}
	
	var pQueue = new Queue<TreeNode>();
	var qQueue = new Queue<TreeNode>();
	
	pQueue.Enqueue(p);
	qQueue.Enqueue(q);
	
	while(pQueue.Count != 0 && qQueue.Count != 0)
	{
		var item1 = pQueue.Dequeue();
		var item2 = qQueue.Dequeue();
		
		if(item1 == null && item2 == null)
		{
			continue;
		}
		if(item1 == null || item2 == null)
		{
			return false;
		}
		if(item1.val != item2.val)
		{
			return false;
		}
		pQueue.Enqueue(item1.left);
		pQueue.Enqueue(item1.right);

		qQueue.Enqueue(item2.left);
		qQueue.Enqueue(item2.right);
	}
	return true;
}

public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}
