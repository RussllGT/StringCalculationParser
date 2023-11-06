using StringCalculation.Nodes;
using StringCalculation.Nodes.Operations.High;
using StringCalculation.Nodes.Operations.Low;
using System.Collections.Generic;

namespace StringCalculation.Parsing.Elements
{
    internal class OperationParser : IParsingElement
    {
        private const char ADDITION_OPERAATION = '+';
        private const char SUBSTRACTION_OPERAATION = '-';
        private const char MULTIPLICATION_OPERAATION = '*';
        private const char DIVISION_OPERAATION = '/';

        public bool Check(char c, LinkedList<BaseNode> nodes)
        {
            switch (c)
            {
                case ADDITION_OPERAATION:
                    nodes.AddLast(new AdditionNode());
                    return true;

                case SUBSTRACTION_OPERAATION:
                    nodes.AddLast(new SubstractionNode());
                    return true;

                case MULTIPLICATION_OPERAATION:
                    nodes.AddLast(new MultiplicationNode());
                    return true;

                case DIVISION_OPERAATION:
                    nodes.AddLast(new DivisionNode());
                    return true;

                default:
                    return false;
            }
        }

        public bool CheckEnd(LinkedList<BaseNode> nodes) => false;
    }
}