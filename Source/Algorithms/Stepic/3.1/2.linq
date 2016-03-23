<Query Kind="Program" />

void Main()
{
	var firstLine = Console.ReadLine().Split(' ');
	int totalRows = int.Parse(firstLine[0]);
	double totalWeight = double.Parse(firstLine[1]);
	Item[] items = new Item[totalRows];
	for (int i = 0; i < totalRows; i++)
	{
		items[i] = new Item(Console.ReadLine());
	}

	double result = Calculate(totalWeight, items);
	
	Console.WriteLine(result.ToString("0.000"));
}

private static double Calculate(double totalWeight, Item[] items)
{
	double result = 0;
	if (totalWeight == 0 || items == null || items.Length == 0)
	{
		return result;
	}

	Item[] sorted = items.OrderByDescending(x=>x.UnitPrice).ToArray();
	
	for (int i = 0; i < sorted.Length; i++)
	{
		Item item = sorted[i];
		if (totalWeight != 0)
		{
			if (item.Weight <= totalWeight)
			{
				result += item.Cost;
				totalWeight -= item.Weight;
			}
			else
			{
				result += item.UnitPrice * totalWeight;
				totalWeight = 0;
			}
		}
		else
		{
			break;
		}
	}
	return result;
}

struct Item
{
	public Item(string line)
	{
		string[] data = line.Split();
		Cost = double.Parse(data[0]);
		Weight = double.Parse(data[1]);
		UnitPrice = Cost/Weight;
	}
	
	public double Cost { get; private set; }
	public double Weight { get; private set; }
	public double UnitPrice { get; private set;}
}
