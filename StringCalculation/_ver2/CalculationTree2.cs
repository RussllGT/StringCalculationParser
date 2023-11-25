using StringCalculation._ver2.Nodes;
using StringCalculation._ver2.Nodes.Arguments;
using StringCalculation.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculation._ver2
{
    public class CalculationTree2
    {
        private BaseNode2 _root;
        public BaseNode2 Root => _root;

        private VariableValuesContainer _variablesContainer;

        private CalculationTree2() { }

        public static CalculationTree2 Create(string expression, IEnumerable<string> externalVariables) 
        {  
            CalculationTree2 result = new CalculationTree2();
            
            LinkedList<BaseNode2> nodes = new StringParser2(externalVariables).Parse(expression, out IEnumerable<string> internalVariables);
            result._variablesContainer = new VariableValuesContainer(externalVariables.Concat(internalVariables));

            foreach(VariableNode2 variable in nodes.Where(n => n is VariableNode2).Cast<VariableNode2>()) variable.RegisterContainer(result._variablesContainer);
            
            result._root = BuildTree(nodes);

            return result; 
        }

        private static BaseNode2 BuildTree(LinkedList<BaseNode2> nodes)
        {
            throw new NotImplementedException();
        }

        public BaseNode2 Calculate(IValueRequest valuesRequest)
        {
            _variablesContainer.SetValues(valuesRequest);
            return _root.Calculate();
        }
    }
}