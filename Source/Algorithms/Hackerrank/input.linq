<Query Kind="Expression" />

private static class Input
{
	private static string _path = @"C:\Users\Serjo\Desktop\input.txt";
	private static string[] _data;
	private static int _lastIndex = -1;

	static Input()
	{
		_data = File.ReadAllLines(_path);
	}

	public static string Line(int index)
	{
		_lastIndex = index;
		return _data[index];
	}

	public static string Next()
	{
		_lastIndex++;
		return _data[_lastIndex];
	}
}