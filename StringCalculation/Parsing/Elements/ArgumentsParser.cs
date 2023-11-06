using StringCalculation.Nodes;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculation.Parsing.Elements
{
    internal class ArgumentsParser : IParsingElement
    {
        private List<char> _variables;

        public ArgumentsParser(IEnumerable<char> variables)
        {
            _variables = variables.ToList();
        }

        public bool Check(char c, LinkedList<BaseNode> nodes)
        {
            foreach(char v in _variables)
            {
                if (v.Equals(c))
                {
                    nodes.AddLast(new ArgumentNode(_variables.IndexOf(v)));
                    return true;
                }
            }
            return false;
        }

        public bool CheckEnd(LinkedList<BaseNode> nodes) => false;
    }
}