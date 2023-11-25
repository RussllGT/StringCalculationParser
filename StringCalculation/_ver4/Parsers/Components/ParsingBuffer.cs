using StringCalculation._ver4.Calculation.Nodes;
using StringCalculation._ver4.General;
using StringCalculation._ver4.Parsers.Readers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculation._ver4.Parsers.Components
{
    public class ParsingBuffer
    {
        public const char END_OF_THE_LINE_SYMBOL = '\n';

        private readonly string _incorrectSymbols;

        private Dictionary<SymbolBufferingResult, ISymbolReader> _readers = new Dictionary<SymbolBufferingResult, ISymbolReader>
        {
            { SymbolBufferingResult.Expression, new BraceReader() },
            { SymbolBufferingResult.Operator, new OperatorReader() },
            { SymbolBufferingResult.Word, new WordReader() },
        };

        public ParsingBuffer() 
        {
            _incorrectSymbols = ExpressionManager.Instance.SymbolsData.IncorrectSymbols
                + ExpressionManager.Instance.SymbolsData.LambdaBraceOpen
                + ExpressionManager.Instance.SymbolsData.LambdaBraceClose;
        }

        public SymbolBufferingInfo ReadSymbol(char symbol)
        {
            if (_incorrectSymbols.Contains(symbol)) throw new ArgumentException($"Некорректный символ в выражении: \'{symbol}\'");

            if (ExpressionManager.Instance.SymbolsData.EmptySymbols.Contains(symbol)) return new SymbolBufferingInfo(SymbolBufferingResult.Read, string.Empty);

            foreach(SymbolBufferingResult buffering in _readers.Keys)
            {
                if (_readers[buffering].ReadSymbol(symbol) is SymbolReadingInfo info)
                {
                    if (info.IsComlete)
                    {
                        if (_readers.ContainsKey(info.Transfer)) _readers[info.Transfer].ReadSymbol(symbol);
                        return new SymbolBufferingInfo(buffering, info.Result);
                    }
                    else return new SymbolBufferingInfo(SymbolBufferingResult.Read, string.Empty);
                }
            }

            if(END_OF_THE_LINE_SYMBOL.Equals(symbol)) return new SymbolBufferingInfo(SymbolBufferingResult.Read, string.Empty);
            else throw new ArgumentException($"Ошибка чтения символа в выражении: \'{symbol}\'");
        }
    }
}