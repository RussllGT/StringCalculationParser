using StringCalculation._ver4.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculation._ver4.Calculation.Nodes
{
    public class ArgumentNode4 : ICalculationNode
    {
        public string Name { get; }

        public ArgumentNode4(string name) { Name = name; }

        public ValueNode4 Calculate() => ExpressionManager.Instance.Arguments[this];
    }
}
