<Query Kind="Program" />

void Main()
{
	
}

public IList<string> BinaryTreePaths(TreeNode root)
{
	if(root == null)
	{
		return new List<string>();
	}
	var result = new List<string>();
	BinaryTreePaths(root, result, string.Empty);
	return result;
}

private void BinaryTreePaths(TreeNode root, List<string> paths, string path)
{
	if(root == null)
	{
		return;
	}
	if(string.IsNullOrEmpty(path))
	{
		path = root.val.ToString();
	}
	else
	{
		path += $"->{root.val}";
	}
	if(root.left == null && root.right == null)
	{
		paths.Add(path);
	}
	else
	{
		BinaryTreePaths(root.left, paths, path);
		BinaryTreePaths(root.right, paths, path);
	}
}


public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}
