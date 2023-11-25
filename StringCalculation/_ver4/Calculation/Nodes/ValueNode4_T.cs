using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculation._ver4.Calculation.Nodes
{
    public class ValueNode4<T> : ValueNode4
    {
        public T Value => (T)_value;
        public ValueNode4(T value) : base(value) { }
    }
}