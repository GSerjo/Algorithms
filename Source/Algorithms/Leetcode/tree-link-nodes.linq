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
}

public sealed class Node
{
	public Node(int value)
	{
		Value = value;
	}
	
	public int Value { get; }
	public Node Left;
	public Node Right;
}
