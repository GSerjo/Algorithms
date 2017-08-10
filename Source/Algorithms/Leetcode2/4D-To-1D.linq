<Query Kind="Program" />

/*

The indexing formula is given by the multiplication of any given dimension value with the product of all the previous dimensions.

Index = xn ( D1 * ... * D{n-1} ) + x{n-1} ( D1 * ... * D{n-2} ) + ... + x2 * D1 + x1
So for 4D

index = x + y * D1 + z * D1 * D2 + t * D1 * D2 * D3;
x = Index % D1;
y = ( ( Index - x ) / D1 ) %  D2;
z = ( ( Index - y * D1 - x ) / (D1 * D2) ) % D3; 
t = ( ( Index - z * D2 * D1 - y * D1 - x ) / (D1 * D2 * D3) ) % D4; 

*/

void Main()
{
	var array = new double[2, 2, 2, 2];
	array.Dump();
	
	var single = ToSingleArray(array).Dump();
	var multi = ToMultiArray(single).Dump();
}


private static double[,,,] ToMultiArray(List<double> array)
{
	var d1 = 2;
	var d2 = 2;
	var d3 = 2;
	var d4 = 2;
	
	var result = new double[d1, d2, d3, d4];
	
	for (int i = 0; i < array.Count; i++)
	{
		var x = i % d1;
		var y = ((i - x) / d1) % d2;
		var z = ((i - y * d1 - x) / (d1 * d2)) % d3;
		var t = ((i - z * d2 * d1 - y * d1 - x) / (d1 * d2 * d3)) % d4;
		
		result[x, y, z, t] = array[i];
	}
	return result;
}

private static List<double> ToSingleArray(double[,,,] array)
{
	double[] dummy = new double[array.GetLength(0) * array.GetLength(1) * array.GetLength(2) * array.GetLength(3)];
	Buffer.BlockCopy(array, 0, dummy, 0, dummy.Length * sizeof(double));
	var result = new List<double>(dummy);
	return result;
}

