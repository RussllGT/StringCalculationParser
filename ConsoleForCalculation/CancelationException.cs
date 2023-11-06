using System;

namespace ConsoleForCalculation
{
    internal class CancelationException : Exception
    {
        public CancelationException(string message) : base(message) { }
    }
}