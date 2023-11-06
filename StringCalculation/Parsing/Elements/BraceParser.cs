using StringCalculation.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculation.Parsing.Elements
{
    internal class BraceParser : IParsingElement
    {
        public const char OPEN_BRACE = '(';
        public const char CLOSE_BRACE = ')';
        public const char ARGUMENT_SEPARATOR = ';';

        private string _expression = string.Empty;
        private bool _isActive = false;
        private int _braceCount = 0;

        private readonly List<char> _variables;

        public BraceParser(IEnumerable<char> externalVariables) { _variables = externalVariables.ToList(); }

        public bool Check(char c, LinkedList<BaseNode> nodes)
        {
            bool result = false;
            if (AddSymbol(c, out string inBraces))
            {
                if (!string.IsNullOrWhiteSpace(inBraces))
                {
                    foreach(string expression in inBraces.Split(ARGUMENT_SEPARATOR))
                    {
                        BaseNode inBracesNode = CalculationTree.Create(expression, _variables).Root;
                        nodes.AddLast(inBracesNode);
                    }
                }
                result = true;
            }
            return result;
        }

        public bool CheckEnd(LinkedList<BaseNode> nodes) => false;

        internal void Open()
        {
            _isActive = true;
        }

        private bool AddSymbol(char c, out string expression)
        {
            expression = string.Empty;
            return CheckOpenBrace(c) || CheckCloseBrace(c, out expression) || CheckActive(c);
        }

        private bool CheckOpenBrace(char c)
        {
            if (OPEN_BRACE.Equals(c))
            {
                if (_isActive)
                {
                    ++_braceCount;
                    _expression += c;
                }
                else
                {
                    Open();
                }
                return true;
            }
            else { return false; }
        }

        private bool CheckCloseBrace(char c, out string expression)
        {
            expression = string.Empty;
            if (CLOSE_BRACE.Equals(c))
            {
                if (_braceCount == 0)
                {
                    expression = _expression;
                    _expression = string.Empty;
                    _isActive = false;
                }
                else
                {
                    --_braceCount;
                    _expression += c;
                }
                return true;
            }
            else { return false; }
        }

        private bool CheckActive(char c)
        {
            if (_isActive) _expression += c;
            return _isActive;
        }
    }
}