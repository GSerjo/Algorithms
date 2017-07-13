<Query Kind="Program" />

void Main()
{
	var source = Directory.GetFiles(@"C:\Work\Ebt\AE2\Intelsat.AE.Common.Tests\TestingFiles\Input\Direct")
						 .ToDictionary(x=>Path.GetFileNameWithoutExtension(x));
	
	
	var binary = Directory.GetFiles(@"C:\Users\Serjo\Desktop\AE\Binary")
						.ToDictionary(x=>Path.GetFileName(x));

	var proto = Directory.GetFiles(@"C:\Users\Serjo\Desktop\AE\Proto")
						.ToDictionary(x => Path.GetFileNameWithoutExtension(x));
	
//	source.Dump();
//	result.Dump();
	
	var lines = new List<string>();
	
	foreach (var pair in source)
	{
		var info = new FileInfo(pair.Value);
		var sourceSize = info.Length / 1024;
		var resultSize = new FileInfo(binary[pair.Key]).Length/1024;
		
		var protoSize = string.Empty;

		if (proto.ContainsKey(pair.Key))
		{
			protoSize = (new FileInfo(proto[pair.Key]).Length/1024).ToString();
		}

		lines.Add($"{pair.Key};{sourceSize};{resultSize};{protoSize}");
	}

	lines.Insert(0, "File;Source Size(KB);Binary Size(KB);Proto Size(KB)");
	lines.Dump();
	File.WriteAllLines(@"C:\Users\Serjo\Desktop\AE\Memory_No_Database.txt", lines);
	
}