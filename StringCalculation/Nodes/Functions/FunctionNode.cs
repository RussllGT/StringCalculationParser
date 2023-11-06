using System;

namespace StringCalculation.Nodes.Functions
{
    internal abstract class FunctionNode : ActionNode
    {
        protected string _name;
        public string Name => _name;

        public int ArgsNum => _nodes.Length;

        public FunctionNode(string name, int argsNum) : base(new BaseNode[argsNum])
        {
            _name = name;
        }

        internal void SetArgument(int argNum, BaseNode node) => _nodes[argNum] = node;
    }
}