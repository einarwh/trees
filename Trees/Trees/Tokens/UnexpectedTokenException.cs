using System;

namespace Trees
{
    public class UnexpectedTokenException : Exception
    {
        public UnexpectedTokenException(string expected, string actual)
            : base(string.Format("Unexpected token. Expected {0}, was {1}.", expected, actual))
        {
        }
    }
}