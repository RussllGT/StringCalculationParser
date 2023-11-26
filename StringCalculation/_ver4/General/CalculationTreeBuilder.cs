using StringCalculation._ver4.Calculation.Nodes;
using StringCalculation._ver4.Calculation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculation._ver4.General
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
                if (current.Value is FunctionNode4 function && function.OperatorType == OperatorTypeEnum.Function && function.IsInvalid)
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
            if (current.Value is FunctionNode4 function && function.OperatorType == OperatorTypeEnum.Negative && function.GetArgument(0) is null)
            {
                function.SetArgument(0, new ConstantNode4(new ValueNode4<double>(0)));
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
                if (node is FunctionNode4 function && function.Priority > maxPriorityValue)
                    maxPriorityValue = function.Priority;
            }

            for (int i = 0; i <= maxPriorityValue; ++i)
            {
                for (LinkedListNode<ICalculationNode> current = nodes.First; !(current is null); current = current.Next)
                {
                    if (IsAvaliableOperator(current.Value, i, out FunctionNode4 function))
                    {
                        function.SetArgument(0, current.Previous.Value);
                        function.SetArgument(1, current.Next.Value);
                        nodes.Remove(current.Previous);
                        nodes.Remove(current.Next);
                    }
                }
            }

            bool IsAvaliableOperator(ICalculationNode func, int index, out FunctionNode4 function)
            {
                function = func as FunctionNode4;
                return !(function is null) && function.Priority == index && function.IsInvalid &&
                    (function.OperatorType == OperatorTypeEnum.Negative || function.OperatorType == OperatorTypeEnum.Operator);
            }
        }
    }
}
