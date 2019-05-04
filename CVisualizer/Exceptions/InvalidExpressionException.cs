using System;

namespace CVisualizer
{
    public class InvalidExpressionException : Exception
    {
        public InvalidExpressionException() : base("Syntax error: Invalid expression.") { }
    }
}
