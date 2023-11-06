using System.Collections.Generic;

namespace StringCalculation.Nodes.Operations.High
{
    internal class DivisionNode : OperationNode
    {
        internal DivisionNode() : base(OperationPriorityEnum.High) { }
        internal override double Calculate(List<double> args) => GetLeftValue(args) / GetRightValue(args);
    }
}