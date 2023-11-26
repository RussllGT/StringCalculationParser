using System;

namespace StringCalculation.General
{
    [Serializable]
    public class SymbolContainerProvider
    {
        public string EmptySymbols { get; set; }
        public string ArgumentsSeparators { get; set; }
        public string OperatorSymbols { get; set; }
        public string IncorrectSymbols { get; set; }
        public char CommonBraceOpen { get; set; }
        public char CommonBraceClose { get; set; }
        public char LambdaBraceOpen { get; set; }
        public char LambdaBraceClose { get; set; }

        public SymbolContainerProvider() { }

        public SymbolContainerProvider(SymbolContainer container) 
        { 
            EmptySymbols = container.EmptySymbols;
            ArgumentsSeparators = container.ArgumentsSeparators;
            OperatorSymbols = container.OperatorSymbols;
            IncorrectSymbols = container.IncorrectSymbols;
            CommonBraceOpen = container.CommonBraceOpen;
            CommonBraceClose = container.CommonBraceClose;
            LambdaBraceOpen = container.LambdaBraceOpen;
            LambdaBraceClose = container.LambdaBraceClose;
        }
    }
}