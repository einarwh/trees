<Query Kind="Program">
  <Reference Relative="..\Trees\Trees\bin\Debug\Trees.dll">E:\hub\trees\Trees\Trees\bin\Debug\Trees.dll</Reference>
  <Namespace>Trees.Parsers</Namespace>
  <Namespace>Trees.Tokens</Namespace>
</Query>

void Main()
{	
	var s = "((x + y) / z)";
	var p = new ArithParser(s);
	var e = p.Parse<Func<int, int, int, int>>();
	var f = e.Compile();
	Console.WriteLine(f(10, 20, 3));
	Console.WriteLine(f(10, 20, 2));
	Console.WriteLine(f(10, 20, 1));
}
