using System.Collections.Generic;

namespace StringCalculation.Nodes
{
    internal abstract class BaseNode
    {
        internal abstract double Calculate(List<double> args);
    }
}