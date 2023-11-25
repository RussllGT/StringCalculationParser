using StringCalculation._ver4.Parsers.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculation._ver4.Parsers.Readers
{
    public class SymbolReadingInfo
    {
        public bool IsComlete { get; }
        public SymbolBufferingResult Transfer { get; }
        public string Result { get; }

        public SymbolReadingInfo(bool isComplete, SymbolBufferingResult transfer, string result)
        {
            IsComlete = isComplete;
            Transfer = transfer;
            Result = result;
        }
    }
}