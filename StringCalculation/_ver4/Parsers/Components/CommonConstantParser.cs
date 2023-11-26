using StringCalculation._ver4.Calculation.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculation._ver4.Parsers.Components
{
    public class CommonConstantParser : IConstantParser
    {
        private const char STRING_WRAPPING = '\"';

        public ValueNode4 Parse(string expression)
        {
            ValueNode4 result;

            if (IsStringWrapped(expression, STRING_WRAPPING.ToString(), STRING_WRAPPING.ToString()))
            {
                result = new ValueNode4<string>(expression.TrimStart(STRING_WRAPPING).TrimEnd(STRING_WRAPPING));
            }
            else if (double.TryParse(expression, out double dValue))
            {
                result = new ValueNode4<double>(dValue);
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
