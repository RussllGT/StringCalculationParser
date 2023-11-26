using StringCalculation._ver4.Calculation.Nodes;
using StringCalculation._ver4.Calculation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleForCalculation.Double
{
    internal class DivisionNode : FunctionNode4
    {
        public const string NAME = "/";
        public DivisionNode() : base(OperatorTypeEnum.Operator, 1) { }

        public override ValueNode4 Calculate()
        {
            if (!(GetArgument(0).Calculate() is ValueNode4<double> leftValue)) throw new ArgumentNullException("Некорректный тип аргумента");
            if (!(GetArgument(1).Calculate() is ValueNode4<double> rightValue)) throw new ArgumentNullException("Некорректный тип аргумента");

            return new ValueNode4<double>(leftValue.Value / rightValue.Value);
        }
    }
}