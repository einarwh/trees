<Query Kind="Program">
  <Reference Relative="..\Trees\Trees\bin\Debug\Trees.dll">E:\hub\trees\Trees\Trees\bin\Debug\Trees.dll</Reference>
  <Namespace>Trees.Tokens</Namespace>
</Query>

void Main()
{	
	var tkz = new ArithTokenizer("((x + y) / z)");
	while (tkz.MoveNext()) {
		Console.WriteLine(tkz.Current);
	}	
}
