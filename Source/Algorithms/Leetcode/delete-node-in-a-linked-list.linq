<Query Kind="Program" />

/*

https://leetcode.com/problems/delete-node-in-a-linked-list/

Write a function to delete a node (except the tail) in a singly linked list, given only access to that node.

Supposed the linked list is 1 -> 2 -> 3 -> 4 and you are given the third node with value 3, the linked list should become 1 -> 2 -> 4 after calling your function.

*/

void Main()
{
	var head = new ListNode(1);
	head.next = new ListNode(2);
	head.next.next = new ListNode(3);
	
	DeleteNode(head.next);
}

private static void DeleteNode(ListNode node)
{
	if (node == null)
	{
		return;
	}
	if (node.next == null)
	{
		node = null;
		return;
	}
	node.val = node.next.val;
	node.next = node.next.next;
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
