<Query Kind="Program">
  <Reference Relative="..\Trees\Trees\bin\Debug\Trees.dll">E:\hub\trees\Trees\Trees\bin\Debug\Trees.dll</Reference>
  <Namespace>Trees.Parsers</Namespace>
  <Namespace>Trees.Tokens</Namespace>
  <Namespace>Trees.Visitors</Namespace>
</Query>

void Show(Expression exp) {
	var gev = new GraphExpressionVisitor();
	gev.Visit(exp);
	var img = gev.CreateGraphImage();
	img.Dump();
}

void Main()
{	
	foreach (var line in File.ReadAllLines(@"E:\hub\trees\Files\arith.txt")) {
		var p = new ArithParser(line);
		var e = p.Parse<Func<int, int, int, int>>();
		Show(e);
		var f = e.Compile();
		var x = 10;
		var y = 20;
		var z = 3;
		Console.WriteLine("f({0}, {1}, {2}) = {3}", x, y, z, f(x, y, z));
		Console.WriteLine();
	}
}