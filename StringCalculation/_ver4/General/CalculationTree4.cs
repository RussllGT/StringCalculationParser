using StringCalculation._ver4.Calculation;
using StringCalculation._ver4.Calculation.Nodes;
using StringCalculation._ver4.Parsers.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculation._ver4.General
{
    public class CalculationTree4
    {
        private readonly ICalculationNode _root;
        private readonly Dictionary<string, ValueNode4> _values = new Dictionary<string, ValueNode4>();

        public IEnumerable<string> Arguments => _values.Keys;
        public int ArgumentsNumber => _values.Count;

        private CalculationTree4(ICalculationNode root, string[] arguments)
        {
            _root = root;
            foreach (string name in arguments) _values.Add(name, null);
        }

        public ValueNode4 Calculate(Dictionary<string, string> arguments)
        {
            foreach (string name in arguments.Keys)
            {
                SetValue(name, ExpressionManager.Instance.ConstantParser.Parse(arguments[name]));
            }
            return _root.Calculate();
        }

        public ValueNode4 GetCalculated(string name)
        {
            if (!_values.ContainsKey(name)) throw new ArgumentException($"Аргумент \"{name}\" не зарегистрирован");
            return _values[name] ?? throw new ArgumentException($"Значение аргумента \"{name}\" не задано");
        }

        private void SetValue(string name, ValueNode4 value)
        {
            if (!_values.ContainsKey(name)) _values[name] = value;
            else throw new ArgumentException($"Аргумент \"{name}\" не зарегистрирован");
        }

        public static CalculationTree4 Create(LinkedList<ICalculationNode> nodes, string[] arguments)
        {
            if (nodes.Count == 0) new ArgumentException("Tokens List is Empty");

            if (nodes.Count == 1 || CalculationTreeBuilder.ProcessNodes(nodes))
            {
                CalculationTree4 result = new CalculationTree4(nodes.First.Value, arguments);
                result._root.RegisterInTree(result);
                return result;
            }
                
            throw new ArgumentException("Incorrect Tokens List Construction");
        }
    }
}
