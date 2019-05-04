using System;

namespace CVisualizer
{
    public class InvalidCharacterException : Exception
    {
        public InvalidCharacterException() : base("Syntax error: Invalid character.") { }
    }
}
