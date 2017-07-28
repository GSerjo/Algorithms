<Query Kind="Program" />

void Main()
{
	var l1 = new ListNode(1);
	
	var l2 = new ListNode(9);
	l2.next = new ListNode(9);
	
	AddTwoNumbers(l1, l2).Dump();
}

private static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
{
	ListNode result = null;
	ListNode current = null;
	var addition = 0;

	while (l1 != null || l2 != null)
	{
		int value = 0;
		if (l1 == null)
		{
			value = l2.val + addition;
			current.next = new ListNode(value % 10);
			current = current.next;
			l2 = l2.next;
		}
		else if (l2 == null)
		{
			value = l1.val + addition;
			current.next = new ListNode(value % 10);
			current = current.next;
			l1 = l1.next;
		}
		else
		{
			value = l1.val + l2.val + addition;
			if (current == null)
			{
				result = new ListNode(value % 10);
				current = result;
			}
			else
			{
				current.next = new ListNode(value % 10);
				current = current.next;
			}
			l1 = l1.next;
			l2 = l2.next;
		}
		
		if (value >= 10)
		{
			addition = 1;
		}
		else
		{
			addition = 0;
		}
	}
	if (addition == 1)
	{
		current.next = new ListNode(1);
	}
	return result;
}


public class ListNode
{
	public int val;
	public ListNode next;
	public ListNode(int x) { val = x; }
}