namespace Trees.Tokens
{
    public static class CharExtensions
    {
        public static bool IsWhiteSpace(this char c)
        {
            return char.IsWhiteSpace(c);
        }

        public static bool IsParenthesis(this char c)
        {
            return c == '(' || c == ')';
        }

        public static bool IsArithOperator(this char c)
        {
            return c == '+' || c == '-' || c == '*' || c == '/';
        }

        public static bool IsSymbolTerminator(this char c)
        {
            return c.IsWhiteSpace() || c.IsParenthesis() || c.IsArithOperator();
        }
    }
}