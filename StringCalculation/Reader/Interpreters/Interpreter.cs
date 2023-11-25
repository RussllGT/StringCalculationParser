using StringCalculation.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculation.Reader.Interpreters
{
    internal abstract class Interpreter
    {
        private readonly List<char> _buffer = new List<char>();

        protected Interpreter() { }

        protected abstract void CheckSymbol(char symbol);
        protected abstract void CheckString(string buffer);
        internal abstract BaseNode GetNode();

        internal void AddSymbol(char symbol) 
        { 
            CheckSymbol(symbol);
            _buffer.Add(symbol);
        }

        internal BaseNode Return()
        {
            CheckString(new string(_buffer.ToArray()));
            return GetNode();
        }

        internal static Interpreter Start(char symbol) { throw new NotImplementedException(); }
    }
}