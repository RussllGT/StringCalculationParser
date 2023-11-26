using StringCalculation.General;

namespace StringCalculation.Calculation
{
    public interface ICalculationNode
    {
        ValueNode Calculate();
        void RegisterInTree(CalculationTree tree);
    }
}