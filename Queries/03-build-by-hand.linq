<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Drawing.dll</Reference>
  <Reference Relative="..\Trees\Trees\bin\Debug\Trees.dll">E:\hub\trees\Trees\Trees\bin\Debug\Trees.dll</Reference>
  <Namespace>System.Drawing</Namespace>
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
	Expression<Func<int, int, int, int>> exp1 = (x, y, z) => (x + (y << 2)) / z; 
	Expression<Func<int, long, long>> exp2 = (x, y) => x + y;
	Expression<Func<string, long, long>> exp3 = (x, y) => x.Length + y;
	
	Show(exp1);
	Show(exp2);
	Show(exp3);
	
	var xExp = Expression.Parameter(typeof(int), "x");
	var yExp = Expression.Parameter(typeof(int), "y");
	var zExp = Expression.Parameter(typeof(int), "z");
	
	var addExp = Expression.Add(xExp, yExp);
	var divideExp = Expression.Divide(addExp, zExp);
	var exp4 = Expression.Lambda(divideExp, xExp, yExp, zExp);
	
	Show(exp4);
	
	var f = exp1.Compile();
	var result = f(10, 3, 2);
	Console.WriteLine(result);
}
