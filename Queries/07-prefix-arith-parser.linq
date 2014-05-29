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
	var pf = new PrefixArithParser("(+ x (* 3 y) z 5)");
	var e = pf.Parse<Func<int, int, int, int>>();
	Show(e);
	
	var f = e.Compile();
	var x = 1;
	var y = 2;
	var z = 3;
	Console.WriteLine("f({0}, {1}, {2}) = {3}", x, y, z, f(x, y, z));
	Console.WriteLine();
}
