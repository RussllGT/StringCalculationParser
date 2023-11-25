using StringCalculation._ver2.Nodes;
using StringCalculation._ver2.Nodes.Arguments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculation._ver2._Numbers
{
    public class DoubleValueNode : ValueNode2
    {
        private readonly double _value;
        public double Value => _value;

        public DoubleValueNode(double value) { _value = value; }
    }
}
