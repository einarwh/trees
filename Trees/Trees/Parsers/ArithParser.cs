using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Trees
{
    public class ArithParser
    {
        protected readonly ArithTokenizer _;
        private readonly Dictionary<string, ParameterExpression> _map;
        protected readonly Dictionary<string, ExpressionType> _ops;

        public ArithParser(string s)
        {
            _ = new ArithTokenizer(s);
            _map = new Dictionary<string, ParameterExpression>();
            _ops = new Dictionary<string, ExpressionType>();
            _ops["+"] = ExpressionType.Add;
            _ops["-"] = ExpressionType.Subtract;
            _ops["*"] = ExpressionType.Multiply;
            _ops["/"] = ExpressionType.Divide;
        }

        public Expression<T> Parse<T>()
        {
            var body = ParseExpression();
            var arr = _map.Values.ToArray();
            return (Expression<T>) Expression.Lambda(typeof(T), body, arr);
        }

        public virtual Expression ParseExpression()
        {
            var token = NextToken();
            if ("(" == token)
            {
                var left = ParseExpression();
                var op = NextToken();
                var right = ParseExpression();
                ConsumeToken(")");
                if (!_ops.ContainsKey(op))
                {
                    throw new Exception("Unknown operation: " + op);
                }

                return Expression.MakeBinary(_ops[op], left, right);
            }
            
            return CreateSymbolExpression(token);
        }

        protected Expression CreateSymbolExpression(string token)
        {
            int val;
            if (int.TryParse(token, out val))
            {
                return Expression.Constant(val);
            }

            var paramExp = Expression.Parameter(typeof(int), token);
            _map[token] = paramExp;
            return paramExp;
        }

        protected string NextToken()
        {
            _.MoveNext();
            return _.Current;
        }

        private void ConsumeToken(string token)
        {
            _.MoveNext();
            if (_.Current != token)
            {
                throw new UnexpectedTokenException(token, _.Current);
            }
        }
    }
}
