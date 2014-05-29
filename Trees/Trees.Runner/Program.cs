using System;
using System.Linq.Expressions;

using Trees.Parsers;
using Trees.Tokens;
using Trees.Visitors;

namespace Trees.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            Expression<Func<int, int, int, int>> exp1 = (x, y, z) => (x + y) / z;
            var viz = new BuildStringExpressionVisitor();
            viz.Visit(exp1);

            var tkz = new ArithTokenizer("( ( foo+bar ) / z)");
            while (tkz.MoveNext())
            {
                Console.WriteLine(tkz.Current);
            }

            var p = new ArithParser("((x * y) / z)");
            var funcExp = p.Parse<Func<int, int, int, int>>();
            var func = funcExp.Compile();
            var result = func(10, 12, 4);
            Console.WriteLine(result);

            Prefix();

            Console.ReadLine();
        }

        private static void Prefix()
        {
            var p = new PrefixArithParser("(+ x y z 5)");
            var funcExp = p.Parse<Func<int, int, int, int>>();
            var func = funcExp.Compile();
            var result = func(10, 12, 4);
            Console.WriteLine(result);
        }
    }
}
