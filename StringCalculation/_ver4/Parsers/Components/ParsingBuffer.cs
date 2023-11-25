﻿using StringCalculation._ver4.Calculation.Nodes;
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
        private readonly string _incorrectSymbols;

        private readonly Dictionary<SymbolBufferingResult, SymbolReader> _readers = new Dictionary<SymbolBufferingResult, SymbolReader>
        {
            { SymbolBufferingResult.Expression, new BraceReader() },
            { SymbolBufferingResult.Operator, new OperatorReader() },
            { SymbolBufferingResult.Word, new WordReader() }
        };
        private SymbolBufferingResult _currentBuffering = SymbolBufferingResult.Read;

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

            foreach (SymbolBufferingResult buffering in SortedReaders())
            {
                if (_readers[buffering].ReadSymbol(symbol) is SymbolReadingInfo info)
                {
                    SymbolBufferingInfo result = new SymbolBufferingInfo(SymbolBufferingResult.Read, string.Empty);
                    if (info.IsComlete)
                    {
                        if (_readers.ContainsKey(info.Transfer)) _readers[info.Transfer].ReadSymbol(symbol);
                        result = new SymbolBufferingInfo(buffering, info.Result);
                    }
                    _currentBuffering = buffering;
                    return result;
                }
            }

            throw new ArgumentException($"Ошибка чтения символа в выражении: \'{symbol}\'");
        }

        private IEnumerable<SymbolBufferingResult> SortedReaders()
        {
            if (_readers.ContainsKey(_currentBuffering)) yield return _currentBuffering;
            foreach(SymbolBufferingResult buffering in _readers.Keys)
            {
                if (_currentBuffering == buffering) continue;
                yield return buffering;
            }
        }
    }
}