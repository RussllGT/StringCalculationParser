using StringCalculation._ver4.General;
using StringCalculation._ver4.Parsers.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculation._ver4.Parsers.Readers
{
    public abstract class SymbolReader
    {
        public const char END_OF_THE_LINE_SYMBOL = '\n';

        protected bool _isActive = false;
        protected string _buffer = string.Empty;

        protected SymbolReader() { }

        public abstract SymbolReadingInfo ReadSymbol(char symbol);

        protected SymbolReadingInfo Open(string buffer)
        {
            _isActive = true;
            _buffer = buffer;
            return SymbolReadingInfo.Empty;
        }

        protected SymbolReadingInfo Close(SymbolBufferingResult transfer = SymbolBufferingResult.Read)
        {
            _isActive = false;
            if (string.IsNullOrWhiteSpace(_buffer)) return SymbolReadingInfo.Empty;

            string temp = _buffer;
            _buffer = string.Empty;
            return new SymbolReadingInfo(true, transfer, temp);
        }

        protected bool IsOpenBrace(char symbol) => ExpressionManager.Instance.SymbolsData.CommonBraceOpen.Equals(symbol);
        protected bool IsCloseBrace(char symbol) => ExpressionManager.Instance.SymbolsData.CommonBraceClose.Equals(symbol);
        protected bool IsOperatorSymbol(char symbol) => ExpressionManager.Instance.SymbolsData.OperatorSymbols.Contains(symbol);
        protected bool IsWordSymbol(char symbol) => !(IsOperatorSymbol(symbol) || IsOpenBrace(symbol));
        protected bool IsEndSymbol(char symbol) => END_OF_THE_LINE_SYMBOL.Equals(symbol);
        protected bool IsSeparationSymbol(char symbol) => ExpressionManager.Instance.SymbolsData.ArgumentsSeparators.Contains(symbol);
    }
}