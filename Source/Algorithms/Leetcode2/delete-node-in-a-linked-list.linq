<Query Kind="Program" />

void Main()
{
	
}

public void DeleteNode(ListNode node)
{
	if(node == null)
	{
		return;
	}
	if(node.next == null)
	{
		node = null;
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