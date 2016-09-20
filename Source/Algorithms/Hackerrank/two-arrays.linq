<Query Kind="Program" />

// https://www.hackerrank.com/challenges/two-arrays

//A better approach is to use the binary tree, but for now naive version

void Main()
{
	var testCount = int.Parse(Console.ReadLine());
//	var testCount = int.Parse(Input.Line(0));
	
	var tests = new List<Test>();
	for (int i = 0; i < testCount; i++)
	{
//		var k = Input.Next().Split(' ')[1];
//		var array1 = Input.Next();
//		var array2 = Input.Next();

		var k = Console.ReadLine().Split(' ')[1];
		var array1 = Console.ReadLine();
		var array2 = Console.ReadLine();
		tests.Add(new Test(array1, array2, k));
	}
	
	var result = new List<string>();
	foreach (var test in tests)
	{
		if(Check(test))
		{
			result.Add("YES");
		}
		else
		{
			result.Add("NO");
		}
	}
	foreach (var item in result)
	{
		Console.WriteLine(item);
	}
}


private static bool Check(Test test)
{
	test.Array1.Sort();
	
	foreach (var item in test.Array2)
	{
		var delta = test.K - item;
		if(delta <= 0)
		{
			test.Array1.RemoveAt(0);
			continue;
		}
		var nearest = test.Array1.OrderBy(x=> x - delta).Where(x=> x >= delta).ToList();
		if(nearest.Count == 0)
		{
			return false;
		}
		test.Array1.Remove(nearest[0]);
	}
	return true;
}

public class Test
{
	public Test(string array1, string array2, string k)
	{
		Array1 = array1.Split(' ').Select(int.Parse).ToList();
		Array2 = array2.Split(' ').Select(int.Parse).ToList();
		K = int.Parse(k);
	}
	
	public List<int> Array1 { get; private set; }
	public List<int> Array2 { get; private set; }
	public int K { get; private set;}
}


private static class Input
{
	private static string _path = @"C:\Users\Serjo\Desktop\input.txt";
	private static string[] _data;
	private static int _lastIndex = -1;

	static Input()
	{
		_data = File.ReadAllLines(_path);
	}

	public static string Line(int index)
	{
		_lastIndex = index;
		return _data[index];
	}
	
	public static string Next()
	{
		_lastIndex++;
		return _data[_lastIndex];
	}
}