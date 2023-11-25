using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculation._ver4.Parsers.Components
{
    public class SymbolBufferingInfo
    {
        public SymbolBufferingResult Result { get; }
        public string Value { get; }

        public SymbolBufferingInfo(SymbolBufferingResult result, string value)
        {
            Result = result;
            Value = value;
        }
    }
}