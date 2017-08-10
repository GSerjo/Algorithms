<Query Kind="Program" />

void Main()
{
	var root = new ListNode(1);
	root.next = new ListNode(2);
	root.next.next = new ListNode(3);
	root.next.next.next = new ListNode(4);
	
	DeleteNode(root.next.next);
	
	root.Dump();
}

public void DeleteNode(ListNode node)
{
	if (node == null)
	{
		return;
	}
	node.val = node.next.val;
	node.next = node.next.next;
}


public class ListNode
{
	public int val;
	public ListNode next;
	public ListNode(int x) { val = x; }
}
