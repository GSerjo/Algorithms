<Query Kind="Program" />

// https://leetcode.com/problems/linked-list-cycle/

void Main()
{
	var head = new ListNode(1);
	head.next = new ListNode(2);
	
	HasCycle(head);
}

private static bool HasCycle(ListNode head)
{
	if(head == null || head.next == null)
	{
		return false;
	}
	
	if(head == head.next)
	{
		return true;
	}
	
	ListNode slow = head;
	ListNode fast = head;
	
	while (fast != null && fast.next != null)
	{
		slow = slow.next;
		fast = fast.next.next;
		
		if (slow == fast)
		{
			return true;
		}
	}
	return false;	
}


public class ListNode
{
	public int val;
	public ListNode next;
	public ListNode(int x) { val = x; }
}
