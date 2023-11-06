using System.Collections.Generic;

namespace StringCalculation.Nodes
{
    internal class NumberNode : BaseNode
    {
        private readonly double _value;
        internal NumberNode(double value) { _value  = value; }
        internal override double Calculate(List<double> args) => _value;
    }
}