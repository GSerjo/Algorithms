<Query Kind="Program" />

//https://www.hackerrank.com/challenges/sparse-arrays
void Main()
{
	var stringCount = int.Parse(Console.ReadLine());
//	var stringCount = int.Parse(Input.Line(0));
	
	var result = new List<int>();
		
	var dictionary = new Dictionary<string, int>();
	for (int i = 0; i < stringCount; i++)
	{
		var input = Console.ReadLine();
//		var input = Input.Line(i + 1);
		
		if(dictionary.ContainsKey(input))
		{
			dictionary[input]++;
		}
		else
		{
			dictionary[input] = 1;
		}
	}

		var queryCount = int.Parse(Console.ReadLine());
//	var queryCount = int.Parse(Input.Line(stringCount + 1));

	for (int i = 0; i < queryCount; i++)
	{
		var input = Console.ReadLine();
//		var input = Input.Line(i + 1 + stringCount + 1);

		if (dictionary.ContainsKey(input))
		{
			result.Add(dictionary[input]);
		}
		else
		{
			result.Add(0);
		}
	}
	result.ForEach(x=>Console.WriteLine(x));
}
