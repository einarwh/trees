namespace Trees
{
    internal class Node
    {
        private readonly string _label;

        private readonly int _hash;

        public Node(int hash, string label)
        {
            _hash = hash;
            _label = label;
        }

        public string Id
        {
            get
            {
                return string.Format("n{0}", _hash);
            }
        }

        public string Label
        {
            get
            {
                return _label;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} [label=\"{1}\"]", Id, Label);
        }
    }
}