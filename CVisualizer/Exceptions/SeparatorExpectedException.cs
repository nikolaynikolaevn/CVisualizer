using System;

namespace CVisualizer
{
    public class SeparatorExpectedException : Exception
    {
        public SeparatorExpectedException() : base("Syntax error: Expected ',' separator.") { }
    }
}
