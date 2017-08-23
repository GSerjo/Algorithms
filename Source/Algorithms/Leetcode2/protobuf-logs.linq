<Query Kind="Program" />

void Main()
{
	var dictionary = new Dictionary<string, int>();
	var lines = File.ReadLines(@"C:\ProgramData\EA\Logs\Protobuf\Full.txt");
	
	foreach (var line in lines)
	{
		var parts = line.Split(new[] { "Id:" }, StringSplitOptions.None);
		if (parts.Length <= 1)
		{
			continue;
		}
		var id = parts[parts.Length - 1];
		if (string.IsNullOrWhiteSpace(id))
		{
			continue;
		}
		if (dictionary.ContainsKey(id))
		{
			dictionary[id]++;
		}
		else
		{
			dictionary[id] = 1;
		}
	}
	dictionary.Dump();
}

