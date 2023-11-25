using StringCalculation._ver4.Calculation.Nodes;
using StringCalculation._ver4.General;
using StringCalculation._ver4.Parsers.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculation._ver4.Parsers
{
    public class CommonExpressionParser : IExpressionParser
    {
        private readonly ParsingBuffer _buffer = new ParsingBuffer();

        public CommonExpressionParser() { }

        public LinkedList<ICalculationNode> Parse(string expression)
        {
            LinkedList<ICalculationNode> result = new LinkedList<ICalculationNode>();

            string[] arguments = ExtractLambda(ref expression);
            ExpressionManager.Instance.Arguments.AddRange(arguments);

            foreach (char symbol in expression) BufferSymbol(_buffer.ReadSymbol(symbol));
            BufferSymbol(_buffer.ReadSymbol(ParsingBuffer.END_OF_THE_LINE_SYMBOL));

            return result;

            void BufferSymbol(SymbolBufferingInfo info)
            {
                switch (info.Result)
                {
                    case SymbolBufferingResult.Read:
                        return;

                    case SymbolBufferingResult.Operator:
                        result.AddLast(GetFunction(info.Value));
                        return;

                    case SymbolBufferingResult.Word:
                        if (CheckFunction(info.Value)) result.AddLast(GetFunction(info.Value));
                        if (CheckArgument(info.Value)) result.AddLast(GetArgument(info.Value));
                        else result.AddLast(GetConstant(info.Value));
                        return;

                    case SymbolBufferingResult.Expression:
                        foreach (ICalculationNode node in new CommonExpressionParser().Parse(info.Value)) 
                        { 
                            result.AddLast(node); 
                        }
                        return;

                    default:
                        throw new ArgumentException("Ошибка чтения символа в строке. Неизвестный результат чтения символа");
                }
            }

            bool CheckFunction(string value) => ExpressionManager.Instance.Functions.Contains(value);
            ICalculationNode GetFunction(string value) => ExpressionManager.Instance.Functions[value];

            bool CheckArgument(string value) => ExpressionManager.Instance.Arguments.Contains(value);
            ICalculationNode GetArgument(string value) => ExpressionManager.Instance.Arguments[value];

            ICalculationNode GetConstant(string value) => ExpressionManager.Instance.ConstantParser.Parse(value);
        }

        private static string[] ExtractLambda(ref string expression)
        {
            expression = expression.Trim(ExpressionManager.Instance.SymbolsData.EmptySymbols.ToCharArray());

            if (!ExpressionManager.Instance.SymbolsData.LambdaBraceOpen.Equals(expression[0])) return new string[0];

            int endIndex = expression.IndexOf(ExpressionManager.Instance.SymbolsData.LambdaBraceClose);
            if (endIndex == -1) throw new ArgumentException("При разборе выражения обнаружена открывающая скобка лямбды, но отсутсвует закрывающая");

            string lambda = expression.Substring(1, endIndex - 1);
            expression = expression.Substring(endIndex + 1);
            return lambda.Split(ExpressionManager.Instance.SymbolsData.ArgumentsSeparators.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
