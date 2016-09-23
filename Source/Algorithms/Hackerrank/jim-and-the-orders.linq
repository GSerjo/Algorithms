<Query Kind="Program" />

// https://www.hackerrank.com/challenges/jim-and-the-orders

void Main()
{
//	var itemsCount = int.Parse(Input.Next());
	var itemsCount = int.Parse(Console.ReadLine());
	
	var items = new List<Item>();
	for (int i = 0; i < itemsCount; i++)
	{
//		var line = Input.Next();
		var line = Console.ReadLine();
		var values = line.Split(' ').Select(int.Parse).ToList();
		
		items.Add(new Item{ Id = i + 1, T = values[0], D = values[1]});
	}
	
	var result = items.OrderBy(x=>x.FinishTime).ThenBy(x=>x.Id).Select(x=>x.Id).ToList();
	
	Console.WriteLine(string.Join(" ", result));
	
}

private struct Item
{
	public int Id { get; set; }
	public int T { get; set; }
	public int D { get; set; }
	
	public int FinishTime 
	{
		get { return T + D;}
	}
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
