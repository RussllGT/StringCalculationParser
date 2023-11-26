using StringCalculation.Calculation;
using System;

namespace ConsoleForCalculation.Double
{
    internal class PowerNode : FunctionNode
    {
        public const string NAME = "Pow";
        public PowerNode() : base(NAME, OperatorTypeEnum.Function, 2) { }

        public override ValueNode Calculate()
        {
            if (!(GetArgument(0).Calculate() is ValueNode<double> leftValue)) throw new ArgumentNullException("Некорректный тип аргумента");
            if (!(GetArgument(1).Calculate() is ValueNode<double> rightValue)) throw new ArgumentNullException("Некорректный тип аргумента");

            return new ValueNode<double>(Math.Pow(leftValue.Value, rightValue.Value));
        }
    }
}