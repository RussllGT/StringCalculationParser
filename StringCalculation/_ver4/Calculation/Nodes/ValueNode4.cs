using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculation._ver4.Calculation.Nodes
{
    public abstract class ValueNode4
    {
        protected object _value;
        public ValueNode4(object value) { _value = value; }
    }
}