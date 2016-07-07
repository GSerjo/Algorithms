<Query Kind="Program" />

// https://leetcode.com/problems/reverse-linked-list/

void Main()
{
	var head =  new ListNode(1);
	head.next = new ListNode(2);
	head.next.next = new ListNode(3);
	
	var result = ReverseList(head);
}

private static ListNode ReverseList(ListNode head)
{
	if(head == null || head.next == null)
	{
		return head;
	}
	
	ListNode result = null;
	
	while (head != null)
	{
		var temp = head.next;
		head.next = result;
		result = head;
		head = temp;
	}
	
	return result;
}


public class ListNode
{
	public int val;
	public ListNode next;
	public ListNode(int x) { val = x; }
}