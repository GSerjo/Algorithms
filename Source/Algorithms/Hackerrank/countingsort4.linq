<Query Kind="Program" />

//https://www.hackerrank.com/challenges/countingsort4

void Main()
{
	var inputs = int.Parse(Console.ReadLine());
//	var inputs = int.Parse(Input.Line(0));
	
	var items = new List<Item>();
	var result = new List<string>();
	
	for (int i = 0; i < inputs; i++)
	{
		var data = Console.ReadLine();
//		var data = Input.Line(i+1);
		
		items.Add(new Item(data, i));
	}
	
	items = items.OrderBy(x=>x.Key).ToList();
	foreach (var item in items)
	{
		if(item.Index < items.Count/2)
		{
			result.Add("-");
		}
		else
		{
			result.Add(item.Value);
		}
	}
	
	Console.WriteLine(string.Join(" ", result));
}

private struct Item
{
	public Item(string data, int index)
	{
		Index = index;
		var values = data.Split(' ');
		Key = int.Parse(values[0]);
		Value = values[1];
	}

	public int Key { get; set; }
	public string Value { get; set; }
	public int Index { get; set; }
}
