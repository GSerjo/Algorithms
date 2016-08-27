<Query Kind="Program" />

void Main()
{
	var root = Insert(null, 5);
	root = Insert(root, 3);
	root = Insert(root, 9);
	
	Lookup(root, 9).Dump();
	Lookup(root, 10).Dump();
}


private static bool Lookup(Node root, int value)
{
	if(root == null)
	{
		return false;
	}
	while(root != null)
	{
		if(root.Value == value)
		{
			return true;
		}
		else if(value > root.Value)
		{
			root = root.Right;
		}
		else
		{
			root = root.Left;
		}
	}
	return false;
}


private static Node Insert(Node root, int value)
{
	if(root == null)
	{
		return new Node(value);
	}
	if(root.Value == value)
	{
		return root;
	}
	if(value > root.Value)
	{
		root.Right = Insert(root.Right, value);
	}
	else
	{
		root.Left = Insert(root.Left, value);
	}
	return root;
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
