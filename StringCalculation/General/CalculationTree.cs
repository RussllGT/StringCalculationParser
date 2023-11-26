using StringCalculation.Calculation;
using System;
using System.Collections.Generic;

namespace StringCalculation.General
{
    public class CalculationTree
    {
        private readonly ICalculationNode _root;
        private readonly Dictionary<string, ValueNode> _values = new Dictionary<string, ValueNode>();

        public IEnumerable<string> Arguments => _values.Keys;
        public int ArgumentsNumber => _values.Count;

        private CalculationTree(ICalculationNode root, string[] arguments)
        {
            _root = root;
            foreach (string name in arguments) _values.Add(name, null);
        }

        public ValueNode Calculate(Dictionary<string, string> arguments)
        {
            foreach (string name in arguments.Keys)
            {
                SetValue(name, ExpressionManager.Instance.ConstantParser.Parse(arguments[name]));
            }
            return _root.Calculate();
        }

        public ValueNode GetCalculated(string name)
        {
            if (!_values.ContainsKey(name)) throw new ArgumentException($"Аргумент \"{name}\" не зарегистрирован");
            return _values[name] ?? throw new ArgumentException($"Значение аргумента \"{name}\" не задано");
        }

        private void SetValue(string name, ValueNode value)
        {
            if (_values.ContainsKey(name)) _values[name] = value;
            else throw new ArgumentException($"Аргумент \"{name}\" не зарегистрирован");
        }

        public static CalculationTree Create(LinkedList<ICalculationNode> nodes, string[] arguments)
        {
            if (nodes.Count == 0) new ArgumentException("Tokens List is Empty");

            if (nodes.Count == 1 || CalculationTreeBuilder.ProcessNodes(nodes))
            {
                CalculationTree result = new CalculationTree(nodes.First.Value, arguments);
                result._root.RegisterInTree(result);
                return result;
            }
                
            throw new ArgumentException("Incorrect Tokens List Construction");
        }
    }
}
