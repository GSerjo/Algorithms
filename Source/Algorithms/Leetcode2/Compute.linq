<Query Kind="Program" />

void Main()
{
	var files = Directory.GetFiles(@"C:\Users\Serjo\Desktop\AE\Grand Performance Testing\M1", "*.txt", SearchOption.AllDirectories);
	foreach (var file in files)
	{
		var content = File.ReadAllLines(file);
		var data = CreateData(content);
		file.Dump();
		var computedData = Compute(data);
		computedData.Dump();
	}
}


private Dictionary<string, double> Compute(Dictionary<string, List<double>> data)
{
	var result = new Dictionary<string, double>();
	var startTime = data["IncomingEndpoint"].Min();
	var endTime = data["OutputCompleted"].Max();
	result["Total (min)"] = (endTime - startTime)/1000/60;
	
	result["AvgTotal (min)"] = data["Total"].Average()/1000/60;
	result["AvgSendTotal (sec)"] = data["SendTotal"].Average()/1000;
	
	result["GeographicAnalysisPreProcessor (min)"] = (data["BeforeGeographicAnalysisAggregationInputQueue"].Average() -
												data["GetFromGeographicAnalysisPreProcessorInputQueue"].Average())/1000/60;
	
	return result;
}


private Dictionary<string, List<double>> CreateData(string[] lines)
{
	var result = new Dictionary<string, List<double>>();
	var headers = lines[0].Split(';');
	foreach (var header in headers)
	{
		result[header] = new List<double>();
	}
	
	for (int i = 1; i < lines.Length; i++)
	{
		var rowItems = lines[i].Split(';');
		
		for (int j = 0; j < rowItems.Length; j++)
		{
			var column = result[headers[j]];
			
			if(string.IsNullOrWhiteSpace(rowItems[j]))
			{
				column.Add(0);
			}
			else
			{
				if (j == 0)
				{
					continue;
				}
				column.Add(double.Parse(rowItems[j]));
			}
		}
	}
	return result;
}

