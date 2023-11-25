using StringCalculation.Nodes.Operations.Low;
using StringCalculation.Nodes.Operations;
using StringCalculation.Nodes;
using System;
using System.Collections.Generic;
using StringCalculation.Parsing;
using StringCalculation.Nodes.Functions;

namespace StringCalculation
{
    public class CalculationTree
    {
        private BaseNode _root;
        internal BaseNode Root => _root;

        private int _dimensions;
        public int Dimensions => _dimensions;

        private CalculationTree() { }

        public static CalculationTree Create(string expression, IEnumerable<char> externalVariables)
        {
            CalculationTree result = new CalculationTree();
            LinkedList<BaseNode> nodes = new StringParser(externalVariables).Parse(expression, out result._dimensions);
            result._root = BuildTree(nodes);
            
            return result;
        }

        public double Calculate(List<double> args) => _root.Calculate(args);

        private static BaseNode BuildTree(LinkedList<BaseNode> nodes)
        {
            if (nodes.Count == 0) new ArgumentException("Tokens List is Empty");
            if (nodes.Count == 1 || ProcessNodes(nodes)) return nodes.First.Value;
            throw new ArgumentException("Incorrect Tokens List Construction");
        }

        private static bool ProcessNodes(LinkedList<BaseNode> nodes)
        {
            SetFunctions(nodes);
            SetNegative(nodes);
            SetOperations(nodes, OperationPriorityEnum.High);
            SetOperations(nodes,OperationPriorityEnum.Low);
            return nodes.Count == 1;
        }

        private static void SetFunctions(LinkedList<BaseNode> nodes)
        {
            for (LinkedListNode<BaseNode> current = nodes.First; !(current is null); current = current.Next)
            {
                if (current.Value is FunctionNode function && function.IsInvalid)
                {
                    for (int i = 0; i < function.ArgsNum; ++i)
                    {
                        function.SetArgument(i, current.Next.Value);
                        nodes.Remove(current.Next);
                    }
                }
            }
        }

        private static void SetNegative(LinkedList<BaseNode> nodes)
        {
            LinkedListNode<BaseNode> current = nodes.First;
            if (current.Value is SubstractionNode negative)
            {
                negative.SetLeft(new NumberNode(0));
                negative.SetRight(current.Next.Value);
                nodes.Remove(current.Next);
            }
        }

        private static void SetOperations(LinkedList<BaseNode> nodes, OperationPriorityEnum priority)
        {
            for (LinkedListNode<BaseNode> current = nodes.First; !(current is null); current = current.Next)
            {
                if (current.Value is OperationNode operation && operation.IsInvalid && operation.Priority == priority)
                {
                    operation.SetLeft(current.Previous.Value);
                    operation.SetRight(current.Next.Value);
                    nodes.Remove(current.Previous);
                    nodes.Remove(current.Next);
                }
            }
        }
    }
}