<Query Kind="Program" />

void Main()
{
	var a = 5;
	var b = 9;
	a = a ^ b;
	
	a.Dump();
	b = a ^ b;
	a = b ^ a;
	
	a.Dump();
	b.Dump();
	
}

// Define other methods and classes here
