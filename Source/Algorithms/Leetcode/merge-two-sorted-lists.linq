<Query Kind="Program" />

// https://leetcode.com/problems/merge-two-sorted-lists/

void Main()
{
	var l1 = new ListNode(1);
	l1.next = new ListNode(2);
	l1.next.next = new ListNode(5);

	var l2 = new ListNode(3);
	l2.next = new ListNode(6);
	
	var result = MergeTwoLists(l1, l2);
}

private static ListNode MergeTwoLists(ListNode l1, ListNode l2)
{
	if(l1 == null)
	{
		return l2;
	}
	if(l2 == null)
	{
		return l1;
	}
	
	var result = new ListNode(0);
	var current = result;
	
	while (l1 != null && l2 != null)
	{
		if(l1.val > l2.val)
		{
			var temp = l2.next;
			current.next = l2;
			current.next.next = null;
			l2 = temp;
		}
		else
		{
			var temp = l1.next;
			current.next = l1;
			current.next.next = null;
			l1 = temp;
		}
		current = current.next;
	}
	
	if(l1 == null)
	{
		current.next = l2;
	}
	else
	{
		current.next = l1;
	}
	
	return result.next;
}

public class ListNode
{
	public int val;
	public ListNode next;
	public ListNode(int x) { val = x; }
}
