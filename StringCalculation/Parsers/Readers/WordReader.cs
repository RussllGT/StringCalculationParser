using StringCalculation.Parsers.Components;
using System;

namespace StringCalculation.Parsers.Readers
{
    public class WordReader : SymbolReader
    {
        public override SymbolReadingInfo ReadSymbol(char symbol)
        {
            if (IsCloseBrace(symbol)) throw new ArgumentException("В выражении некорректно расставлены скобки");

            if (IsEndSymbol(symbol) || IsSeparationSymbol(symbol)) return Close();
            if (_isActive)
            {
                if (IsWordSymbol(symbol))
                {
                    _buffer += symbol;
                    return SymbolReadingInfo.Empty;
                }
                else
                {
                    SymbolBufferingResult transfer = IsOpenBrace(symbol) ? SymbolBufferingResult.Expression : SymbolBufferingResult.Operator;
                    return Close(transfer);
                }
            }
            else
            {
                if (IsWordSymbol(symbol)) return Open(symbol.ToString());
                return null;
            }
        }
    }
}