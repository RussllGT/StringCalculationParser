using System.Collections.Generic;

namespace StringCalculation.Nodes
{
    internal class ArgumentNode : BaseNode
    {
        private readonly int _index;
        internal ArgumentNode(int index) { _index = index; }
        internal override double Calculate(List<double> args) => args[_index];
    }
}