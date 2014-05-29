using System.Linq.Expressions;

namespace Trees.Visitors
{
    public class AddToMultiplyVisitor : ExpressionVisitor
    {
        protected override Expression VisitBinary(BinaryExpression node)
        {
            if (node.NodeType == ExpressionType.Add)
            {
                return Expression.Multiply(Visit(node.Left), Visit(node.Right));
            }
            return base.VisitBinary(node);
        }
    }
}
