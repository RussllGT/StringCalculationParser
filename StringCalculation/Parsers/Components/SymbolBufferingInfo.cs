namespace StringCalculation.Parsers.Components
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