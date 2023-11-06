using System.Collections.Generic;

namespace StringCalculation.Nodes.Operations
{
    internal abstract class OperationNode : ActionNode
    {
        protected readonly OperationPriorityEnum _priority;
        public OperationPriorityEnum Priority => _priority;

        protected OperationNode(OperationPriorityEnum priority) : base(new BaseNode[2]) { _priority = priority; }

        protected double GetLeftValue(List<double> args) => _nodes[0].Calculate(args);
        protected double GetRightValue(List<double> args) => _nodes[1].Calculate(args);

        internal void SetLeft(BaseNode token) => _nodes[0] = token;
        internal void SetRight(BaseNode token) => _nodes[1] = token;
    }
}