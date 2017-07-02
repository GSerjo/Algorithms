<Query Kind="Program" />

void Main()
{
	//var lines = File.ReadAllLines(Path.Combine(Path.GetDirectoryName(Util.CurrentQueryPath), "4.2.1.txt"));
	var lines = Console.ReadLine();
	
	var numbers = lines.Split(' ');
	
	var lettersCount = int.Parse(numbers[0]);
	
	var letters = new Dictionary<string, string>();
	for (int i = 0; i < lettersCount; i++)
	{
		//var line = lines[i + 1];
		var line = Console.ReadLine();
		
		var items = line.Split(':');
		letters[items[1].Trim()] = items[0].Trim();
	}
	
	//var code = lines[lines.Length - 1];
	var code = Console.ReadLine();
	
	var result = new StringBuilder();
	
	var letterCode = new StringBuilder();
	
	foreach (var item in code)
	{
		letterCode.Append(item);
		if(letters.ContainsKey(letterCode.ToString()))
		{
			result.Append(letters[letterCode.ToString()]);
			letterCode.Clear();
		}
	}
	Console.WriteLine(result.ToString());
}

