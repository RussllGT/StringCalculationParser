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
        public static readonly SymbolReadingInfo Empty = new SymbolReadingInfo(false, SymbolBufferingResult.Read, string.Empty);

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