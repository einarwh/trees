using System;
using System.Collections;
using System.Collections.Generic;

namespace Trees.Tokens
{
    public class ArithTokenizer : IEnumerator<string>
    {
        private readonly string _;

        private int _pos;

        private string _current;

        public ArithTokenizer(string s)
        {
            _ = s;
            _pos = -1;
        }

        public void Dispose()
        {
        }

        private char? NextChar
        {
            get
            {
                int nextIndex = _pos + 1;
                if (nextIndex < _.Length)
                {
                    return _[nextIndex];
                }

                return null;
            }
        }

        public bool MoveNext()
        {
            return MoveBeforeToken() && MoveToken();
        }

        private bool MoveToken()
        {
            var nc = NextChar;
            if (!nc.HasValue)
            {
                throw new Exception("Illegal state.");
            }

            int start = ++_pos;
            if (nc.Value.IsParenthesis() || nc.Value.IsArithOperator())
            {
                _current = _.Substring(start, 1);
                return true;
            }

            return MoveSymbol(start);
        }

        private bool MoveSymbol(int start)
        {
            var nc = NextChar;
            while (nc.HasValue)
            {
                var c = nc.Value;
                if (c.IsSymbolTerminator())
                {
                    int end = _pos + 1;
                    int len = end - start;
                    _current = _.Substring(start, len);
                    return true;
                }

                ++_pos;
                nc = NextChar;
            }

            _current = _.Substring(start, _.Length);
            return true;
        }

        private bool MoveBeforeToken()
        {
            var nc = NextChar;
            if (nc.HasValue)
            {
                if (nc.Value.IsWhiteSpace())
                {
                    ++_pos;
                    return MoveBeforeToken();
                }

                return true;
            }

            return false;
        }

        public void Reset()
        {
            _pos = -1;
        }

        public string Current
        {
            get
            {
                return _current;
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }
    }
}