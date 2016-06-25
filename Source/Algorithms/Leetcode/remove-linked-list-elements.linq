<Query Kind="Program" />

// https://leetcode.com/problems/remove-linked-list-elements/

void Main()
{

	var head = new ListNode(6);
	head.next = new ListNode(2);
	head.next.next = new ListNode(6);
	head.next.next.next = new ListNode(3);
	head.next.next.next.next = new ListNode(6);
	
	var result = RemoveElements(head, 6);
}

private static ListNode RemoveElements(ListNode head, int val)
{
	ListNode result = null;
	ListNode current= null;
	
	while (head != null)
	{
		var temp = head.next;
		if(head.val != val)
		{
			if(result == null)
			{
				result = head;
				current = result;
				result.next = null;
			}
			else
			{
				current.next = head;
				current.next.next = null;
				current = current.next;
			}
		}
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
