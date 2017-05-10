<Query Kind="Program" />

/*

     4
   /   \
  2-----7
 / \   / \
1---3-6---9

*/

void Main()
{

}

private static void Link(Node root)
{
	if (root == null)
	{
		return;
	}
	Link(root.Left, root.Right);
}

private static void Link(Node node1, Node node2)
{
	if (node1 == null && node2 == null)
	{
		return;
	}
	if (node1 == null)
	{
		Link(node2.Left, node2.Right);
	}
	if (node2 == null)
	{
		Link(node1.Left, node1.Right);
	}
	else
	{
		node1.Link = node2;
		node2.Link = node1;
		Link(node1.Left, node1.Right);
		Link(node2.Left, node2.Right);
		Link(node1.Right, node2.Left);
	}
}

public sealed class Node
{
	public int Value;
	public Node Left;
	public Node Right;
	public Node Link;
	public Node(int value) { Value = value; }
}

