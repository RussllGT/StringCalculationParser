using System.Collections.Generic;

namespace StringCalculation.Nodes.Operations.High
{
    internal class MultiplicationNode : OperationNode
    {
        internal MultiplicationNode() : base(OperationPriorityEnum.High) { }
        internal override double Calculate(List<double> args) => GetLeftValue(args) * GetRightValue(args);
    }
}