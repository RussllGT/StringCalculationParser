using StringCalculation._ver2.Interpreters;
using StringCalculation._ver2.Nodes;
using StringCalculation.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculation._ver2
{
    internal class StringParser2
    {
        private const char EMPTY_SYMBOL = ' ';

        private readonly List<string> _variables;

        private IStringInterpreter _currentInterpreter;

        public StringParser2(IEnumerable<string> externalVariables)
        {
            _variables = new List<string>();
            AddVariables(externalVariables);
        }

        private void AddVariables(IEnumerable<string> externalVariables)
        {
            int index = 0;
            foreach (string variable in externalVariables)
            {
                ++index;
                if (string.IsNullOrWhiteSpace(variable)) throw new ArgumentException($"Incorrect variable name. Variable number: {index}");
                if (_variables.Contains(variable)) throw new ArgumentException($"Variables duplication. Variable numbers: {_variables.IndexOf(variable) + 1}, {index}");
                _variables.Add(variable);
            }
        }

        public LinkedList<BaseNode2> Parse(string value, out IEnumerable<string> internalVariables)
        {
            LinkedList<BaseNode2> result = new LinkedList<BaseNode2>();
            internalVariables = new List<string>();

            foreach (char c in value)
            {
                if (EMPTY_SYMBOL.Equals(c)) continue;


            }

            return result;
        }
    }
}
