<Query Kind="Program" />

//https://www.hackerrank.com/challenges/sherlock-and-watson
void Main()
{
	var input = Console.ReadLine().Split(' ').Select(x=>int.Parse(x)).ToArray();
//	var input = Input.Line(0).Split(' ').Select(x=>int.Parse(x)).ToArray();
	
	int n = input[0];
	int k = input[1];
	int q = input[2];

	var array = Console.ReadLine().Split(' ').Select(x=>int.Parse(x)).ToArray();
//	var array = Input.Line(1).Split(' ').Select(x=>int.Parse(x)).ToArray();
	
	var result = new List<int>();	
	if(k == array.Length)
	{
		k = 0;
	}
	else if(k > array.Length)
	{
		k = k % array.Length;
	}
	
	for (int i = 0; i < q; i++)
	{
		int index = int.Parse(Console.ReadLine()) - k;
//		int index = int.Parse(Input.Line(i+2)) - k;
		
		if(index < 0)
		{
			index = index + array.Length;
		}
		result.Add(array[index]);
	}
	result.ForEach(x=>Console.WriteLine(x));
}
