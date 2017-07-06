<Query Kind="Program" />

void Main()
{
	var source = Directory.GetFiles(@"C:\Work\Ebt\AE2\Intelsat.AE.Common.Tests\TestingFiles\Input\Direct")
						 .ToDictionary(x=>Path.GetFileNameWithoutExtension(x));
	
	
	var result = Directory.GetFiles(@"C:\Work\Ebt\AE2\Intelsat.AE.Analysis.Performance.Test\bin\Debug")
						.ToDictionary(x=>Path.GetFileName(x));
	
//	source.Dump();
//	result.Dump();
	
	var lines = new List<string>();
	
	foreach (var pair in source)
	{
		var info = new FileInfo(pair.Value);
		var sourceSize = info.Length / 1024;
		var resultSize = new FileInfo(result[pair.Key]).Length/1024;

		lines.Add($"{pair.Key};{sourceSize};{resultSize}");
	}

	lines.Insert(0, "File;Source Size(KB);Binary Size(KB)");
	lines.Dump();
	File.WriteAllLines(@"C:\Users\Serjo\Desktop\AE\Memory__No_Database.txt", lines);
	
}

