using StringCalculation.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculation._ver2.Nodes
{
    public abstract class ActionNode2 : BaseNode2
    {
        protected BaseNode2[] _nodes;
        public bool IsInvalid => _nodes.Any(n => n is null);
        protected ActionNode2(BaseNode2[] nodes) { _nodes = nodes; }
    }
}