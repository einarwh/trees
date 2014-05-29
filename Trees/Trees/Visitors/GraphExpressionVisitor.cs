using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq.Expressions;
using System.Text;

namespace Trees.Visitors
{
    public class GraphExpressionVisitor : ExpressionVisitor
    {
        private readonly List<Edge> _edges = new List<Edge>();

        private readonly List<Node> _nodes = new List<Node>(); 

        protected override Expression VisitLambda<T>(Expression<T> node)
        {
            return base.Visit(node.Body);
        }

        protected override Expression VisitBinary(BinaryExpression node)
        {
            var n = new Node(node.GetHashCode(), node.NodeType.ToString());
            _nodes.Add(n);
            var left = new Node(node.Left.GetHashCode(), node.Left.NodeType.ToString());
            var right = new Node(node.Right.GetHashCode(), node.Right.NodeType.ToString());
            _edges.Add(new Edge(n, left));
            _edges.Add(new Edge(n, right));
            return base.VisitBinary(node);
        }

        protected override Expression VisitUnary(UnaryExpression node)
        {
            var source = new Node(node.GetHashCode(), node.NodeType.ToString());
            var target = new Node(node.Operand.GetHashCode(), node.Operand.NodeType.ToString());
            _nodes.Add(source);
            _edges.Add(new Edge(source, target));
            return base.VisitUnary(node);
        }

        protected override Expression VisitParameter(ParameterExpression node)
        {
            _nodes.Add(new Node(node.GetHashCode(), node.Name));
            return base.VisitParameter(node);
        }

        protected override Expression VisitConstant(ConstantExpression node)
        {
            _nodes.Add(new Node(node.GetHashCode(), node.Value.ToString()));
            return base.VisitConstant(node);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("digraph G {");
            
            foreach (var n in _nodes)
            {
                sb.Append("  ").AppendLine(n.ToString());
            }

            foreach (var e in _edges)
            {
                sb.Append("  ").AppendLine(e.ToString());
            }
            
            sb.AppendLine("}");
            return sb.ToString();
        }

        public Image CreateGraphImage()
        {
            const string Gvpath = @"C:\tools\Graphviz2.38\bin";
            var s = ToString();
            var baseFileName = string.Format("g-{0}", DateTime.UtcNow.Ticks);
            var dotFileName = baseFileName + ".txt";
            var dotFilePath = Path.Combine(Gvpath, dotFileName);
            File.WriteAllText(dotFilePath, s);
            var startInfo = new ProcessStartInfo
                                {
                                    WorkingDirectory = Gvpath,
                                    FileName = "dot.exe",
                                    Arguments = string.Format("-Tpng -O {0}", dotFilePath)
                                };
            var p = Process.Start(startInfo);
            p.WaitForExit();
            return Image.FromFile(dotFilePath + ".png");
        }
    }
}
