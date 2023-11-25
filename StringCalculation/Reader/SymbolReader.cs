using StringCalculation.Reader.Interpreters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StringCalculation.Reader
{
    internal class SymbolReader
    {
        private readonly string _expression;
        private Interpreter _interpreter;


        internal SymbolReader(string expression)
        {
            _expression = expression;
        }

        internal void Read()
        {
            foreach(char symbol in _expression)
            {
                if (_interpreter is null) _interpreter = Interpreter.Start(symbol);
                else _interpreter.AddSymbol(symbol);

                //Проверить состояние интерпретатора
            }

        }
    }
}
