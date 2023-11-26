using StringCalculation.Calculation;

namespace StringCalculation.Parsers.Components
{
    public interface IConstantParser
    {
        ValueNode Parse(string expression);
    }
}