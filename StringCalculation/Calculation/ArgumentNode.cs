using StringCalculation.General;

namespace StringCalculation.Calculation
{
    public class ArgumentNode : ICalculationNode
    {
        private CalculationTree _tree;

        public string Name { get; }

        public ArgumentNode(string name) { Name = name; }

        public ValueNode Calculate() => _tree.GetCalculated(Name);

        public void RegisterInTree(CalculationTree tree) => _tree = tree;
    }
}
