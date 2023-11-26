using StringCalculation._ver4.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculation._ver4.Calculation.Nodes
{
    public abstract class FunctionNode4 : ICalculationNode
    {
        public OperatorTypeEnum OperatorType { get; }
        public int Priority { get; }
        public ICalculationNode[] Arguments { get; }
        public int ArgumentsNumber => Arguments.Length;
        public bool IsInvalid => ArgumentsNumber > 0 && Arguments.Any(node => node is null);

        public FunctionNode4(OperatorTypeEnum operatorType, int index) 
        {
            OperatorType = operatorType;
            switch (OperatorType)
            {
                case OperatorTypeEnum.Function:
                    Priority = 0;
                    Arguments = new ICalculationNode[index];
                    break;

                case OperatorTypeEnum.Operator:
                    Priority = index;
                    Arguments = new ICalculationNode[2];
                    break;

                case OperatorTypeEnum.Negative:
                    Priority = index;
                    Arguments = new ICalculationNode[2];
                    break;

                case OperatorTypeEnum.Prefix:
                    Priority = index;
                    Arguments = new ICalculationNode[1];
                    break;

                case OperatorTypeEnum.Postfix:
                    Priority = index;
                    Arguments = new ICalculationNode[1];
                    break;
            }
        }

        public ICalculationNode GetArgument(int argNum) => Arguments[argNum];

        public void SetArgument(int argNum, ICalculationNode argument) => Arguments[argNum] = argument;

        public abstract ValueNode4 Calculate();

        public void RegisterInTree(CalculationTree4 tree)
        {
            foreach(ICalculationNode node in Arguments) node.RegisterInTree(tree);
        }
    }
}