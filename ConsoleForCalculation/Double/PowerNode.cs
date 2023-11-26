using StringCalculation._ver4.Calculation;
using StringCalculation._ver4.Calculation.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleForCalculation.Double
{
    internal class PowerNode : FunctionNode4
    {
        public const string NAME = "Pow";
        public PowerNode() : base(OperatorTypeEnum.Function, 2) { }

        public override ValueNode4 Calculate()
        {
            if (!(GetArgument(0).Calculate() is ValueNode4<double> leftValue)) throw new ArgumentNullException("Некорректный тип аргумента");
            if (!(GetArgument(1).Calculate() is ValueNode4<double> rightValue)) throw new ArgumentNullException("Некорректный тип аргумента");

            return new ValueNode4<double>(Math.Pow(leftValue.Value, rightValue.Value));
        }
    }
}