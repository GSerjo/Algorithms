<Query Kind="Program" />

/*

https://leetcode.com/problems/linked-list-cycle/

Given a linked list, determine if it has a cycle in it.

*/

void Main()
{
	var head = new ListNode(1);
	head.next = new ListNode(2);
	HasCycle(head).Dump();
}

private static bool HasCycle(ListNode head)
{
	if (head == null)
	{
		return false;
	}
	var fast = head;
	var slow = head;
	while (fast.next != null && fast.next.next != null)
	{
		slow = fast.next;
		fast = fast.next.next;
		if (fast == slow)
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
    public ListNode(int x)
	{
        val = x;
        next = null;
    }
}