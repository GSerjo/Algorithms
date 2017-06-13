<Query Kind="Program" />

void Main()
{
	
}


public bool IsSameTree(TreeNode p, TreeNode q)
{
	if (p == q)
	{
		return true;
	}
	if (p == null || q == null)
	{
		return false;
	}
	var queueP = new Queue<TreeNode>();
	queueP.Enqueue(p);
	
	var queueQ = new Queue<TreeNode>();
	queueQ.Enqueue(q);
	while (queueP.Count != 0 && queueP.Count != 0)
	{
		var nodeQ = queueQ.Dequeue();
		var nodeP = queueP.Dequeue();
		if (nodeP == null && nodeQ == null)
		{
			continue;
		}
		if (nodeQ == null || nodeP == null)
		{
			return false;
		}
		if (nodeP.val != nodeQ.val)
		{
			return false;
		}
		queueP.Enqueue(nodeP.left);
		queueQ.Enqueue(nodeQ.left);
		
		queueP.Enqueue(nodeP.right);
		queueQ.Enqueue(nodeQ.right);
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