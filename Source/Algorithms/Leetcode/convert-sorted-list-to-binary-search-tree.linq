<Query Kind="Program" />

/*

https://leetcode.com/problems/convert-sorted-list-to-binary-search-tree/

Given a singly linked list where elements are sorted in ascending order, convert it to a height balanced BST.

*/

void Main()
{

}

private static TreeNode SortedListToBST(ListNode head)
{
	if (head == null)
	{
		return null;
	}
	return SortedListToBST(head, null);
}

private static TreeNode SortedListToBST(ListNode head, ListNode tail)
{
	if (head == tail)
	{
		return null;
	}
	var slow = head;
	var fast = head;
	while (fast != tail && fast.next != tail)
	{
		fast = fast.next.next;
		slow = slow.next;
	}
	var node = new TreeNode(slow.val);
	node.left = SortedListToBST(head, slow);
	node.right = SortedListToBST(slow.next, tail);
	return node;
}

public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}

public class ListNode
{
	public int val;
	public ListNode next;
	public ListNode(int x) { val = x; }
}