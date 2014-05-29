using System.Collections.Generic;
using System.Linq.Expressions;

namespace Trees.Parsers
{
    public class PrefixArithParser : ArithParser
    {
        public PrefixArithParser(string s) : base(s)
        {
        }

        public override Expression ParseExpression()
        {
            var token = NextToken();
            if (")" == token)
            {
                return null;
            }

            if ("(" == token)
            {
                var op = NextToken();
                var stack = new Stack<Expression>();
                while (true)
                {
                    var e = ParseExpression();
                    if (e == null)
                    {
                        break;
                    }
                    stack.Push(e);
                }

                var tree = stack.Pop();
                foreach (var e in stack)
                {
                    tree = Expression.MakeBinary(_ops[op], e, tree);
                }

                return tree;

            }
            
            return CreateSymbolExpression(token);
        }
    }
}
