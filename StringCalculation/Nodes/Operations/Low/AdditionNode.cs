using System.Collections.Generic;

namespace StringCalculation.Nodes.Operations.Low
{
    internal class AdditionNode : OperationNode
    {
        internal AdditionNode() : base(OperationPriorityEnum.Low) { }
        internal override double Calculate(List<double> args) => GetLeftValue(args) + GetRightValue(args);
    }
}