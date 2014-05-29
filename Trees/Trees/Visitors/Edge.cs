namespace Trees.Visitors
{
    internal class Edge
    {
        private readonly Node _source;
        private readonly Node _target;

        public Edge(Node source, Node target)
        {
            _source = source;
            _target = target;
        }

        public Node Source
        {
            get
            {
                return _source;
            }
        }

        public Node Target
        {
            get
            {
                return _target;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} -> {1};", Source.Id, Target.Id);
        }
    }
}