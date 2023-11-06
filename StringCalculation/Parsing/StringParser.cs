using StringCalculation.Nodes;
using StringCalculation.Nodes.Operations;
using StringCalculation.Parsing.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace StringCalculation.Parsing
{
    internal class StringParser
    {
        private const char NUMBER_SEPARATOR = '.';
        private const char EMPTY_SYMBOL = ' ';

        private const char END_OF_STRING = '\n';

        private List<IParsingElement> _parsers;

        private readonly List<char> _variables;

        public StringParser(IEnumerable<char> externalVariables) { _variables = externalVariables.ToList(); }

        public LinkedList<BaseNode> Parse(string value, out int dimensions)
        {
            LinkedList<BaseNode> result = new LinkedList<BaseNode>();

            _variables.AddRange(GetGraphAnalysis(ref value));
            dimensions = _variables.Count;

            _parsers = new List<IParsingElement>
            {
                new FunctionParser(),
                new BraceParser(_variables),
                new ArgumentsParser(_variables),
                new NumberParser(NUMBER_SEPARATOR),
                new OperationParser()
            };

            foreach (char c in value)
            {
                if (EMPTY_SYMBOL.Equals(c) || IsSymbolParsingCorrect(c, result)) continue;
                throw new ArgumentException("Incorrect symbol");
            }
            IsSymbolParsingCorrect(END_OF_STRING, result);

            return result;
        }

        private List<char> GetGraphAnalysis(ref string value)
        {
            List<char> result = new List<char>();
            if (value.StartsWith("func"))
            {
                int start = value.IndexOf(BraceParser.OPEN_BRACE) + 1;
                int length = value.IndexOf(BraceParser.CLOSE_BRACE) - start;

                string cut;
                foreach(string str in value.Substring(start, length).Split(BraceParser.ARGUMENT_SEPARATOR))
                {
                    cut = str.Replace(" ", "");
                    if (cut.Length == 1) result.Add(cut[0]);
                    else throw new ArgumentException("Incorrect Graph Argument");
                }

                start = value.IndexOf('=') + 1;
                length= value.Length - start;
                value = value.Substring(start, length);
            }
            return result;
        }

        private bool IsSymbolParsingCorrect(char c, LinkedList<BaseNode> nodes)
        {
            if (END_OF_STRING.Equals(c))
            {
                foreach (IParsingElement parser in _parsers)
                {
                    if (parser.CheckEnd(nodes)) return true;
                }
            }
            else
            {
                foreach (IParsingElement parser in _parsers)
                {
                    if (parser.Check(c, nodes)) return true;
                }
            }
            return false;
        }
    }
}