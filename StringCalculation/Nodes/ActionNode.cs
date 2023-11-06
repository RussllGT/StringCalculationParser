using System.Linq;

namespace StringCalculation.Nodes
{
    internal abstract class ActionNode : BaseNode
    {
        protected BaseNode[] _nodes;
        public bool IsInvalid => _nodes.Any(n => n is null);
        protected ActionNode(BaseNode[] nodes) { _nodes = nodes; }
    }
}