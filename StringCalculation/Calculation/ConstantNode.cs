using StringCalculation.General;

namespace StringCalculation.Calculation
{
    public class ConstantNode : ICalculationNode
    {
        private readonly ValueNode _value;

        public ConstantNode(ValueNode value) { _value = value; }

        public ValueNode Calculate() => _value;

        public void RegisterInTree(CalculationTree tree) { }
    }
}