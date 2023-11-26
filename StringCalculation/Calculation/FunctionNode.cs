using StringCalculation.General;
using System.Linq;

namespace StringCalculation.Calculation
{
    public abstract class FunctionNode : ICalculationNode
    {
        public string Name { get; }
        public OperatorTypeEnum OperatorType { get; }
        public int Priority { get; }
        public ICalculationNode[] Arguments { get; }
        public int ArgumentsNumber => Arguments.Length;
        public bool IsInvalid => ArgumentsNumber > 0 && Arguments.Any(node => node is null);

        public FunctionNode(string name, OperatorTypeEnum operatorType, int index) 
        {
            Name = name;
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

        public abstract ValueNode Calculate();

        public void RegisterInTree(CalculationTree tree)
        {
            foreach(ICalculationNode node in Arguments) node.RegisterInTree(tree);
        }
    }
}