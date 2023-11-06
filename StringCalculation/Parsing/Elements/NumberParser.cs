using StringCalculation.Nodes;
using System;
using System.Collections.Generic;
using System.Threading;

namespace StringCalculation.Parsing.Elements
{
    internal class NumberParser : IParsingElement
    {
        private readonly char _separator;
        private string _buffer = string.Empty;
        public NumberParser(char separator) { _separator = separator; }

        public bool Check(char c, LinkedList<BaseNode> nodes)
        {
            bool result = false;
            if (AddSymbol(c, out double number)) result = true;
            else if (!double.IsNaN(number)) nodes.AddLast(new NumberNode(number));
            return result;
        }

        public bool CheckEnd(LinkedList<BaseNode> nodes)
        {
            double value = GetNumber();
            if (double.IsNaN(value)) return false;

            nodes.AddLast(new NumberNode(value));
            return true;
        }

        private bool AddSymbol(char c, out double value)
        {
            value = double.NaN;
            if (IsNumberPart(c))
            {
                _buffer += c;
                return true;
            }
            else
            {
                value = GetNumber();
                return false;
            }
        }

        public double GetNumber()
        {
            if (string.IsNullOrWhiteSpace(_buffer))
            {
                return double.NaN;
            }
            else if (double.TryParse(GetReplacedBufferValue(), out double value))
            {
                _buffer = string.Empty;
                return value;
            }
            else
            {
                throw new ArgumentException("Incorrect number buffer");
            }
        }

        private bool IsNumberPart(char c) => _separator.Equals(c) || char.IsDigit(c);
        private string GetReplacedBufferValue() => _buffer.Replace(_separator.ToString(), Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator);
    }
}