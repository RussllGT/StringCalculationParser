using StringCalculation._ver4.Calculation;
using StringCalculation._ver4.Calculation.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculation._ver4._Examples
{
    public class AdditionDoubleNode : FunctionNode4
    {
        public const string NAME = "Double Sum";
        public AdditionDoubleNode() : base(OperatorTypeEnum.Operator, 2) { }

        public override ValueNode4 Calculate()
        {
            if (!(GetArgument(0).Calculate() is ValueNode4<double> leftValue)) throw new ArgumentNullException("Некорректный тип аргумента");
            if (!(GetArgument(1).Calculate() is ValueNode4<double> rightValue)) throw new ArgumentNullException("Некорректный тип аргумента");

            return new ValueNode4<double>(leftValue.Value + rightValue.Value);
        }
    }
}