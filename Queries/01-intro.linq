<Query Kind="Program">
  <Namespace>System.Drawing</Namespace>
</Query>

void Main()
{
	Expression<Func<int, int, int, int>> exp = (x, y, z) => (x + y) / z;
	exp.NodeType.Dump();
	var lamExp = (LambdaExpression) exp;
	lamExp.Parameters.Dump();
	var binExp = (BinaryExpression) lamExp.Body;
	var leftExp = (BinaryExpression) binExp.Left;
	var rightExp = (ParameterExpression) binExp.Right;
	binExp.Left.Dump();
	binExp.Right.Dump();
	
	var xExp = (ParameterExpression) leftExp.Left;
	var yExp = (ParameterExpression) leftExp.Right;
    xExp.Dump();
	yExp.Dump();
		
}
