using System.Drawing;
using System.Linq.Expressions;

using Trees.Visitors;

namespace Trees
{
    public static class ExpressionExtensions
    {
        public static Image ToImage(this Expression exp)
        {
            var gev = new GraphExpressionVisitor();
            gev.Visit(exp);
            return gev.CreateGraphImage();
        }
    }
}
