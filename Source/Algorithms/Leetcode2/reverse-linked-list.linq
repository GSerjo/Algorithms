<Query Kind="Program" />

void Main()
{
	var head = new ListNode(1);
	head.next = new ListNode(2);
	head.next.next = new ListNode(3);
	
	ReverseList(head).Dump();
}


private static ListNode ReverseList(ListNode head)
{
	if (head == null)
	{
		return null;
	}
	ListNode prev = null;
	var current = head;
	while (current != null)
	{
		var next = current.next;
		current.next = prev;
		prev = current;
		current = next;
	}
	head = prev;
	return head;
}

public class ListNode
{
	public int val;
	public ListNode next;
	public ListNode(int x) { val = x; }
}