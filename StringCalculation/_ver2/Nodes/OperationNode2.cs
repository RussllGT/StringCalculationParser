using StringCalculation.Nodes.Operations;
using StringCalculation.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StringCalculation._ver2.Nodes.Arguments;

namespace StringCalculation._ver2.Nodes
{
    public abstract class OperationNode2 : ActionNode2
    {
        protected readonly int _priority;
        public int Priority => _priority;

        protected BaseNode2 LeftValue => _nodes[0].Calculate();
        protected BaseNode2 RightValue => _nodes[1].Calculate();

        protected OperationNode2(int priority) : base(new BaseNode2[2]) { _priority = priority; }

        internal void SetLeft(BaseNode2 token) => _nodes[0] = token;
        internal void SetRight(BaseNode2 token) => _nodes[1] = token;
    }
}