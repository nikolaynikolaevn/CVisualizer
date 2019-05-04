using System;

namespace CVisualizer
{
    public class IsNotValidNaturalNumberException : Exception
    {
        public IsNotValidNaturalNumberException() : base("Syntax error: invalid natural number.") { }
    }
}
