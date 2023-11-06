using System.Collections.Generic;

namespace StringCalculation.Nodes.Operations.Low
{
    internal class SubstractionNode : OperationNode
    {
        internal SubstractionNode() : base(OperationPriorityEnum.Low) { }
        internal override double Calculate(List<double> args) => GetLeftValue(args) - GetRightValue(args);
    }
}