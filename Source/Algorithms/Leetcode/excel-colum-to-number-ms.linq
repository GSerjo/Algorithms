<Query Kind="Program" />

/*

Excel Column To Number

A B AA ABB
1 2	27 730

*/

private static Dictionary<char, int> _letter = new Dictionary<char, int>();

void Main()
{
	var temp = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
	for (int i = 0; i < temp.Length; i++)
	{
		_letter.Add(temp[i], i + 1);
	}
	ExcelColumnToNumber("ABB").Dump();
	ExcelColumnToNumber("AA").Dump();

	ExcelColumnToNumber2("ABB").Dump();
	ExcelColumnToNumber2("AA").Dump();
}

private static int ExcelColumnToNumber2(string column)
{
	if (string.IsNullOrWhiteSpace(column))
	{
		return 0;
	}
	if(column.Length == 1)
	{
		return _letter[column[0]];
	}
	var common = 1;
	var result = _letter[column[column.Length - 1]];
	for (int i = column.Length - 2; i >= 0; i--)
	{	
		common*=_letter.Count;
		result += _letter[column[i]] * common;
	}
	return result;
}

private static int ExcelColumnToNumber(string column)
{
	var result = 0;
	if(string.IsNullOrWhiteSpace(column))
	{
		return 0;
	}
	
	for (int i = 0; i < column.Length; i++)
	{
		result += _letter[column[i]] * (int)Math.Pow(_letter.Count, column.Length - i - 1);
	}
	return result;
}