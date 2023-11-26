using StringCalculation.Calculation;
using System;

namespace StringCalculation.Parsers.Components
{
    public class CommonConstantParser : IConstantParser
    {
        private const char STRING_WRAPPING = '\"';

        public ValueNode Parse(string expression)
        {
            ValueNode result;

            if (IsStringWrapped(expression, STRING_WRAPPING.ToString(), STRING_WRAPPING.ToString()))
            {
                result = new ValueNode<string>(expression.TrimStart(STRING_WRAPPING).TrimEnd(STRING_WRAPPING));
            }
            else if (double.TryParse(expression, out double dValue))
            {
                result = new ValueNode<double>(dValue);
            }
            else
            {
                throw new ArgumentException("Не удалось проеобразовать значение");
            }
            return result;
        }

        private bool IsStringWrapped(string value, string start, string end) => value.StartsWith(start) && value.EndsWith(end);
    }
}
