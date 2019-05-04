using System;

namespace CVisualizer
{
    public class MissingBracketException : Exception
    {
        public MissingBracketException() : base("Syntax error: Missing opening or closing bracket.") { }
    }
}
