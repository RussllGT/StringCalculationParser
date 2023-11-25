using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculation._ver4.Calculation.Nodes
{
    public abstract class FunctionNode4 : ICalculationNode
    {
        public int Priority { get; }
        public ICalculationNode[] Arguments { get; }
        public int ArgumentsNumber => Arguments.Length;

        public FunctionNode4(OperatorType operatorType, int index) 
        {
            switch (operatorType)
            {
                case OperatorType.Function:
                    Priority = 0;
                    Arguments = new ICalculationNode[index];
                    break;

                case OperatorType.Operator:
                    Priority = index;
                    Arguments = new ICalculationNode[2];
                    break;

                case OperatorType.Negative:
                    Priority = index;
                    Arguments = new ICalculationNode[2];
                    break;

                case OperatorType.Prefix:
                    Priority = index;
                    Arguments = new ICalculationNode[1];
                    break;

                case OperatorType.Postfix:
                    Priority = index;
                    Arguments = new ICalculationNode[1];
                    break;
            }
        }

        public ICalculationNode GetArgument(int argNum) => Arguments[argNum];

        public void SetArgument(int argNum, ICalculationNode argument) => Arguments[argNum] = argument;

        public abstract ValueNode4 Calculate();
    }
}