<Query Kind="Program" />

void Main()
{
	var result = new List<string>();

	var content = File.ReadAllLines(@"C:\Users\Serjo\Desktop\Help\contact.txt");
	var header = content[0].Split(',');
	foreach (var line in content.Skip(1))
	{
		var items = line.Trim().Split(',');
		var email = items[0].Trim();
		var firstName = items[1].Trim();
		var lastName = string.IsNullOrWhiteSpace(items[2].Trim()) ? firstName: items[2].Trim();
		
		var newValues = new string[header.Length];
		newValues[1] = firstName;
		newValues[3] = lastName;
		newValues[0] = newValues[1] + " " + newValues[3];
		newValues[28] = email;
		
		result.Add(string.Join(",", newValues));
	}
	File.WriteAllLines(@"C:\Users\Serjo\Desktop\Help\contact_part2.csv", result);
}

