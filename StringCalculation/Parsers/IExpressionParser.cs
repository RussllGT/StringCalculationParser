using StringCalculation.Calculation;
using System.Collections.Generic;

namespace StringCalculation.Parsers
{
    public interface IExpressionParser
    {
        LinkedList<ICalculationNode> Parse(string expression);
    }
}
