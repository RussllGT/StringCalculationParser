using StringCalculation._ver2.Nodes.Arguments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculation._ver2
{
    public class VariableValuesContainer
    {
        private readonly Dictionary<string, ValueNode2> _variableValues;
        public ValueNode2 this[string variable] => _variableValues.ContainsKey(variable) ? _variableValues[variable] : null;

        public VariableValuesContainer(IEnumerable<string> variables)
        {
            _variableValues = variables.ToDictionary(v => v, v => null as ValueNode2);
        }

        public void SetValues(IValueRequest request)
        {
            foreach(string variable in _variableValues.Keys)
            {
                _variableValues[variable] = request.GetValue(variable);
            }
        }
    }
}