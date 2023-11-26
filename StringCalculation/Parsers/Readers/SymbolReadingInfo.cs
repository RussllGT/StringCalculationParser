using StringCalculation.Parsers.Components;

namespace StringCalculation.Parsers.Readers
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