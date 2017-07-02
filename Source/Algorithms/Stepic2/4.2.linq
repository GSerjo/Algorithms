<Query Kind="Program" />

void Main()
{
	Huffman("abacabad");
}

private static Dictionary<char, Letter> Huffman(string word)
{
	if(string.IsNullOrWhiteSpace(word))
	{
		return new Dictionary<char, Letter>();
	}
	
	var letters = new Dictionary<char, Letter>();
	
	foreach (var item in word)
	{
		if(letters.ContainsKey(item))
		{
			letters[item].Count++;
		}
		else
		{
			letters[item] = new Letter { Key = item, Count = 1 };
		}
	}
	
	if(letters.Count == 1)
	{
		letters.First().Value.Code = "0";
		return letters;
	}
	
	CreateTree(letters);
	
	return new Dictionary<char, Letter>();
}

private static Node CreateTree(Dictionary<char, Letter> letters)
{
	var list = new MinHeap();
	foreach (var item in letters)
	{
		list.Insert(item.Value);
	}
	return new Node();
	
//	while(list.Size != 0)
//	{
//	}
}

private class Node
{
	public Letter Left;
	public Letter Right;
}

private class Letter
{
	public char Key;
	public int Count;
	public string Code;
}

private class MinHeap
{
	private Letter[] _letters = new Letter[2];
	private int _size = 0;
	
	public int Size
	{
		get
		{
			return _size;
		}
	}
	
	public void Insert(Letter letter)
	{
		if(_letters.Length == _size + 1)
		{
			Resize();
		}
		_letters[++_size] = letter;
		Swim(_size);
	}
	
	public Letter Remove()
	{
		var result = _letters[1];
		Swap(1, _size--);
		_letters[_size+1] = null;
		Sink(1);
		return result;
	}
	
	private void Sink(int number)
	{
		while(2 * number <= _size)
		{
			int j = 2*number;
			if(j < _size && Greater(j, j+1))
			{
				j++;
			}
			if(!Greater(number,j))
			{
				break;
			}
			Swap(number, j);
			number = j;
		}
	}
	
	private void Swim(int number)
	{
		while (number > 1 && Greater(number/2, number))
		{
			Swap(number/2, number);
			number = number/2;
		}
	}
	
	private void Swap(int i, int j)
	{
		var dummy = _letters[i];
		_letters[i] = _letters[j];
		_letters[j] = dummy;
	}
	
	private bool Greater(int i, int j)
	{
		return _letters[i].Count > _letters[j].Count;
	}
	
	private void Resize()
	{
		var dummy = new Letter[_letters.Length * 2];
		Array.Copy(_letters, dummy, _letters.Length);
		_letters = dummy;
	}
}
