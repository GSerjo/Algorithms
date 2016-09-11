<Query Kind="Program" />

void Main()
{
	var content = File.ReadAllLines(@"C:\Users\Serjo\Desktop\Help\google.csv");
	var result = new List<string>();
	
	for (int i = 0; i < content.Length; i++)
	{
		if (i == 0)
		{
			result.Add(content[i]);
			continue;
		}
		var values = content[i].Split(',');

		if (string.IsNullOrWhiteSpace(values[0].Trim()) && string.IsNullOrWhiteSpace(values[1].Trim()) && string.IsNullOrWhiteSpace(values[3].Trim()))
		{
			values[1] = "John";
			values[3] = "Doe";
			values[0] = values[1] + " " + values[3];
		}
		
		result.Add(string.Join(",", values));
		var t = string.Join(",", values).Split(',');
	}
	
	File.WriteAllLines(@"C:\Users\Serjo\Desktop\Help\google_updated.csv", result);
	
	result.Dump();
}

// Define other methods and classes here
