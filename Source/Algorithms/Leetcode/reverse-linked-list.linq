<Query Kind="Program" />

// https://leetcode.com/problems/reverse-linked-list/

void Main()
{
	
}

private static ListNode ReverseList(ListNode head)
{
	if(head == null || head.next == null)
	{
		return head;
	}
	
	ListNode result = null;
	
	return result;
}


public class ListNode
{
	public int val;
	public ListNode next;
	public ListNode(int x) { val = x; }
}
