using StringCalculation.Parsers.Components;
using System;

namespace StringCalculation.Parsers.Readers
{
    public class OperatorReader : SymbolReader
    {
        public override SymbolReadingInfo ReadSymbol(char symbol)
        {
            if (IsCloseBrace(symbol)) throw new ArgumentException("В выражении некорректно расставлены скобки");

            if (IsEndSymbol(symbol) || IsSeparationSymbol(symbol)) return Close();
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
                if (IsOperatorSymbol(symbol)) return Open(symbol.ToString());
                return null;
            }
        }
    }
}