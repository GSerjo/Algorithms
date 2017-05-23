<Query Kind="Program" />

/*

https://leetcode.com/problems/remove-duplicates-from-sorted-list/

Given a sorted linked list, delete all duplicates such that each element appear only once.

For example,
Given 1->1->2, return 1->2.
Given 1->1->2->3->3, return 1->2->3.

*/

void Main()
{
	var head = new ListNode(1);
	head.next = new ListNode(1);
	head.next.next = new ListNode(1);
	
	DeleteDuplicates(head);
}

private static ListNode DeleteDuplicates(ListNode head)
{
	var current = head;
	while (current != null && current.next != null)
	{
		if (current.val == current.next.val)
		{
			var temp = current.next.next;
			while (temp != null)
			{
				if (temp.val == current.val)
				{
					temp = temp.next;
				}
				else
				{
					break;
				}
			}
			current.next = temp;
			current = temp;
		}
		else
		{
			current = current.next;
		}
	}
	return head;
}

public class ListNode
{
	public int val;
	public ListNode next;
	public ListNode(int x)
	{
		val = x;
		next = null;
	}
}
