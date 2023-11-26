﻿using StringCalculation.Calculation;
using System;

namespace ConsoleForCalculation.Double
{
    internal class AdditionNode : FunctionNode
    {
        public const string NAME = "+";
        public AdditionNode() : base(NAME, OperatorTypeEnum.Operator, 2) { }

        public override ValueNode Calculate()
        {
            if (!(GetArgument(0).Calculate() is ValueNode<double> leftValue)) throw new ArgumentNullException("Некорректный тип аргумента");
            if (!(GetArgument(1).Calculate() is ValueNode<double> rightValue)) throw new ArgumentNullException("Некорректный тип аргумента");

            return new ValueNode<double>(leftValue.Value + rightValue.Value);
        }
    }
}