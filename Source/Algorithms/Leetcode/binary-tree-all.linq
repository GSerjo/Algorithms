<Query Kind="Program" />

/*
	   15
	  /  \
     6    18
    / \
   3   7
        \
	     13
	    /
	   9 
*/

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

	Predecessor(root).Dump();
	Predecessor(root.Left.Right.Right.Left).Dump();
	
	SearchRecursive(root, 13).Value.Dump();
	(SearchRecursive(root, 33) == null).Dump();

	SearchIterative(root, 13).Value.Dump();
	(SearchIterative(root, 33) == null).Dump();
	
	root = InsertRecursive(root, 16);
	root = InsertInerative(root, 17);
}

private Node InsertInerative(Node root, int value)
{
	if(root == null)
	{
		return new Node(value);
	}
	var result = root;
	var previous = root;
	while(root != null)
	{
		if(root.Value == value)
		{
			return root;
		}
		if(value > root.Value)
		{
			previous = root;
			root = root.Right;
		}
		else
		{
			previous = root;
			root = root.Left;
		}
	}
	var node = new Node(value)
	{
	 	Parent = previous
	};
	if(value > previous.Value)
	{
		previous.Right = node; 
	}
	else
	{
		previous.Left = node;
	}
	return result;
}

private Node InsertRecursive(Node root, int value)
{
	if(root == null)
	{
		return new Node(value);
	}
	if(value > root.Value)
	{
		var right = InsertRecursive(root.Right, value);
		right.Parent = root;
		root.Right = right;
	}
	else if(value < root.Value)
	{
		var left = InsertRecursive(root.Left, value);
		left.Parent = root;
		root.Left = left;
	}
	return root;
}

private Node SearchRecursive(Node root, int value)
{
	if(root == null)
	{
		return null;
	}
	if(root.Value == value)
	{
		return root;
	}
	if(value > root.Value)
	{
		return SearchRecursive(root.Right, value);
	}
	return SearchRecursive(root.Left, value);
}

private Node SearchIterative(Node root, int value)
{
	if(root == null)
	{
		return null;
	}
	while(root != null)
	{
		if(root.Value == value)
		{
			return root;
		}
		if(value > root.Value)
		{
			root = root.Right;
		}
		else
		{
			root = root.Left;
		}
	}
	return null;
}

private static int Predecessor(Node node)
{
	if(node != null && node.Left != null)
	{
		return Max(node.Left);
	}
	var node2 = node.Parent;
	while(node2 != null && node == node2.Left)
	{
		node = node2;
		node2 = node.Parent;
	}
	return node2.Value;
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