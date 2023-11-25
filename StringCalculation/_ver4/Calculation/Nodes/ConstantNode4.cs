using StringCalculation._ver4.General;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculation._ver4.Calculation.Nodes
{
    public class ConstantNode4 : ICalculationNode
    {
        private readonly ValueNode4 _value;

        public ConstantNode4(ValueNode4 value) { _value = value; }

        public ValueNode4 Calculate() => _value;
    }
}