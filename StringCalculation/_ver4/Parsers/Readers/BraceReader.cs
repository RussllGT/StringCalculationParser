using StringCalculation._ver4.General;
using StringCalculation._ver4.Parsers.Components;
using System;

namespace StringCalculation._ver4.Parsers.Readers
{
    public class BraceReader : SymbolReader
    {
        private int _count = 0;

        public BraceReader() { }

        public override SymbolReadingInfo ReadSymbol(char symbol)
        {
            if (IsEndSymbol(symbol)) return Close();
            if (_isActive)
            {
                if (IsCloseBrace(symbol))
                {
                    if (_count > 0)
                    {
                        --_count;
                        _buffer += symbol;
                        return SymbolReadingInfo.Empty;
                    }
                    else if (_count == 0) return Close();
                    else throw new ArgumentException("В выражении некорректно расставлены скобки");
                }
                else
                {
                    if (IsOpenBrace(symbol))
                    {
                        ++_count;
                        _buffer += symbol;
                    }
                    return SymbolReadingInfo.Empty;
                }
            }
            else
            {
                if (IsOpenBrace(symbol)) return Open();
                else return null;
            }
        }
    }
}