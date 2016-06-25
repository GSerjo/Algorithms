<Query Kind="Program" />

// https://leetcode.com/problems/delete-node-in-a-linked-list/

void Main()
{
	var toDelete = new ListNode(2);
	
	var head = new ListNode(1);
	head.next = toDelete;
	head.next.next = new ListNode(3);
	head.next.next.next = new ListNode(4);
	
	DeleteNode(toDelete);
}

private static void DeleteNode(ListNode node)
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
	var next = node.next;
	node.next = null;
	node.val = next.val;
	node.next = next.next;	
}


public class ListNode
{
	public int val;
	public ListNode next;
	public ListNode(int x) { val = x; }
}