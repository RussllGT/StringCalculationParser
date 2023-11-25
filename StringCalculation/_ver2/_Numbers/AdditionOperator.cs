using StringCalculation._ver2.Nodes;
using StringCalculation._ver2.Nodes.Arguments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculation._ver2._Numbers
{
    internal class AdditionOperator : OperationNode2
    {
        public AdditionOperator() : base(2) { }

        public override BaseNode2 Calculate()
        {
            if (LeftValue is ResultNode<double> left && RightValue is ResultNode<double> right)
            {
                return new ResultNode<double>(left.Result + right.Result);
            }
            else throw new ArgumentException("Некорректный тип аргумента");
        }
    }
}