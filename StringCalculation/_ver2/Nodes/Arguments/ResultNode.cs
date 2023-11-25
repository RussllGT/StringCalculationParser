using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculation._ver2.Nodes.Arguments
{
    internal class ResultNode<T> : ValueNode2
    {
        private readonly T _result;
        public T Result => _result;

        public ResultNode(T result) { _result = result; }
    }
}
