using StringCalculation._ver4.General;
using StringCalculation._ver4.Parsers.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculation._ver4.Parsers.Readers
{
    public class OperatorReader : SymbolReader
    {
        public override SymbolReadingInfo ReadSymbol(char symbol)
        {
            if (IsCloseBrace(symbol)) throw new ArgumentException("В выражении некорректно расставлены скобки");

            if (IsEndSymbol(symbol)) return Close();
            if (_isActive)
            {
                if (IsOperatorSymbol(symbol))
                {
                    _buffer += symbol;
                    return SymbolReadingInfo.Empty;
                }
                else
                {
                    SymbolBufferingResult transfer = IsOpenBrace(symbol) ? SymbolBufferingResult.Expression : SymbolBufferingResult.Word;
                    return Close(transfer);
                }
            }
            else
            {
                if (IsOperatorSymbol(symbol)) return Open();
                return null;
            }
        }
    }
}