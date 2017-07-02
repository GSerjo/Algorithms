<Query Kind="Program" />

void Main()
{
	var input = "abacabad";
	
	//var input = Console.ReadLine();
	
	var letters = Huffman(input);
	var code = new StringBuilder();
	
	foreach (var item in input)
	{
		code.Append(letters[item].Code);
	}
	Console.WriteLine("{0} {1}", letters.Count, code.Length);
	foreach (var item in letters.Values.OrderBy(x=>x.Key))
	{
		Console.WriteLine("{0}: {1}", item.Key, item.Code); 
	}
	Console.WriteLine(code.ToString());
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
	
	var tree = CreateTree(letters);
	UpdateCodeHuffman(tree, letters, string.Empty);
	
	return letters;
}

private static void UpdateCodeHuffman(Letter node, Dictionary<char, Letter> letters, string code)
{
	if(node == null)
	{
		return;
	}
	if(node.Left == null && node.Right == null)
	{
		letters[node.Key].Code = code;
	}
	UpdateCodeHuffman(node.Left, letters, code + "0");
	UpdateCodeHuffman(node.Right, letters, code + "1");
}

private static Letter CreateTree(Dictionary<char, Letter> letters)
{
	var heap = new MinHeap();
	foreach (var item in letters)
	{
		heap.Insert(item.Value);
	}
	
	while(heap.Size != 1)
	{
		var item1 = heap.Remove();
		var item2 = heap.Remove();
		
		var node = new Letter
		{
			Left = item1,
			Right = item2,
			Count = item1.Count + item2.Count
		};
		heap.Insert(node);
	}
	var result = heap.Remove();
	return result;
}

private class Letter
{
	public char Key;
	public int Count;
	public string Code;

	public Letter Left;
	public Letter Right;
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
