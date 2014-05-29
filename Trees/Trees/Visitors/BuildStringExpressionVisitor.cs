using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Trees.Visitors
{
    public class BuildStringExpressionVisitor : ExpressionVisitor
    {
        private readonly Stack<string> _stack = new Stack<string>();

        protected override Expression VisitLambda<T>(Expression<T> node)
        {
            try
            {
                return base.Visit(node.Body);
            }
            finally
            {
                Console.WriteLine(_stack.Pop());
            }
        }

        protected override Expression VisitBinary(BinaryExpression node)
        {
            try
            {
                return base.VisitBinary(node);
            }
            finally
            {
                var right = _stack.Pop();
                var left = _stack.Pop();
                var s = string.Format("({0} {1} {2})", left, node.NodeType, right);
                _stack.Push(s);
            }
        }

        protected override Expression VisitConstant(ConstantExpression node)
        {
            _stack.Push(node.Value.ToString());
            return base.VisitConstant(node);
        }

        protected override Expression VisitParameter(ParameterExpression node)
        {
            _stack.Push(node.Name);
            return base.VisitParameter(node);
        }
    }
}
