<Query Kind="Program" />

void Main()
{
	var root = new Node(15);
	root.Left = new Node(6){ Parent = root };
	root.Right = new Node(18){ Parent = root };
	
	root.Left.Left = new Node(3){ Parent = root.Left };
	root.Left.Right = new Node(7) { Parent = root.Left };;
	
	root.Left.Right.Right = new Node(13){ Parent = root.Left.Right };;
	root.Left.Right.Right.Left = new Node(9) { Parent = root.Left.Right.Right };;
	
	Min(root).Dump();
	Max(root).Dump();
	
	Succesor(root.Left.Right).Dump();
	Succesor(root.Left.Right.Right).Dump();
}

// next > value
private static int Succesor(Node node)
{
	if(node != null && node.Right != null)
	{
		return Min(node.Right);
	}
	var node2 = node.Parent;
	while(node2 != null && node == node2.Right)
	{
		node = node2;
		node2 = node.Parent;
	}
	return node2.Value;
}

private static int Min(Node root)
{
	if(root == null)
	{
		throw new NullReferenceException();
	}
	
	while(root != null && root.Left != null)
	{
		root = root.Left;	
	}
	return root.Value;
}


private static int Max(Node root)
{
	if (root == null)
	{
		throw new NullReferenceException();
	}

	while (root != null && root.Right != null)
	{
		root = root.Right;
	}
	return root.Value;
}


public class Node
{
	public Node(int value)
	{
		Value = value;
	}
	public int Value {get;}
	public Node Left;
	public Node Right;
	public Node Parent;
}
