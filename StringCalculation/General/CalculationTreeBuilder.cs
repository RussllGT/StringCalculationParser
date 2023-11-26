using StringCalculation.Calculation;
using System.Collections.Generic;

namespace StringCalculation.General
{
    internal static class CalculationTreeBuilder
    {
        internal static bool ProcessNodes(LinkedList<ICalculationNode> nodes)
        {
            SetFunctions(nodes);
            SetNegative(nodes);
            SetPrefixAndPostfix(nodes);
            SetOperations(nodes);
            return nodes.Count == 1;
        }

        private static void SetFunctions(LinkedList<ICalculationNode> nodes)
        {
            for (LinkedListNode<ICalculationNode> current = nodes.First; !(current is null); current = current.Next)
            {
                if (current.Value is FunctionNode function && function.OperatorType == OperatorTypeEnum.Function && function.IsInvalid)
                {
                    for (int i = 0; i < function.ArgumentsNumber; ++i)
                    {
                        function.SetArgument(i, current.Next.Value);
                        nodes.Remove(current.Next);
                    }
                }
            }
        }

        private static void SetNegative(LinkedList<ICalculationNode> nodes)
        {
            LinkedListNode<ICalculationNode> current = nodes.First;
            if (current.Value is FunctionNode function && function.OperatorType == OperatorTypeEnum.Negative && function.GetArgument(0) is null)
            {
                function.SetArgument(0, new ConstantNode(new ValueNode<double>(0)));
                function.SetArgument(1, current.Next.Value);
                nodes.Remove(current.Next);
            }
        }

        private static void SetPrefixAndPostfix(LinkedList<ICalculationNode> nodes)
        {

        }

        private static void SetOperations(LinkedList<ICalculationNode> nodes)
        {
            int maxPriorityValue = 0;
            foreach (ICalculationNode node in nodes)
            {
                if (node is FunctionNode function && function.Priority > maxPriorityValue)
                    maxPriorityValue = function.Priority;
            }

            for (int i = 0; i <= maxPriorityValue; ++i)
            {
                for (LinkedListNode<ICalculationNode> current = nodes.First; !(current is null); current = current.Next)
                {
                    if (IsAvaliableOperator(current.Value, i, out FunctionNode function))
                    {
                        function.SetArgument(0, current.Previous.Value);
                        function.SetArgument(1, current.Next.Value);
                        nodes.Remove(current.Previous);
                        nodes.Remove(current.Next);
                    }
                }
            }

            bool IsAvaliableOperator(ICalculationNode func, int index, out FunctionNode function)
            {
                function = func as FunctionNode;
                return !(function is null) && function.Priority == index && function.IsInvalid &&
                    (function.OperatorType == OperatorTypeEnum.Negative || function.OperatorType == OperatorTypeEnum.Operator);
            }
        }
    }
}
