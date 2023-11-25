using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculation._ver4.General
{
    public class SymbolContainer
    {
        public string EmptySymbols { get; }
        public string ArgumentsSeparators { get; }
        public string OperatorSymbols { get; }
        public string IncorrectSymbols { get; }
        public char CommonBraceOpen { get; }
        public char CommonBraceClose { get; }
        public char LambdaBraceOpen { get; }
        public char LambdaBraceClose { get; }


        public SymbolContainer(SymbolContainerProvider provider) 
        { 
            EmptySymbols = provider.EmptySymbols;
            ArgumentsSeparators = provider.ArgumentsSeparators;
            OperatorSymbols = provider.OperatorSymbols;
            IncorrectSymbols = provider.IncorrectSymbols;
            CommonBraceOpen = provider.CommonBraceOpen;
            CommonBraceClose = provider.CommonBraceClose;
            LambdaBraceOpen = provider.LambdaBraceOpen;
            LambdaBraceClose = provider.LambdaBraceClose;
        }

        public static SymbolContainer CreateDefault() 
        {
            SymbolContainerProvider provider = new SymbolContainerProvider
            {
                EmptySymbols = " ",
                ArgumentsSeparators = ";",
                OperatorSymbols = "+-/*",
                IncorrectSymbols = string.Empty,
                CommonBraceOpen = '(',
                CommonBraceClose = ')',
                LambdaBraceOpen = '[',
                LambdaBraceClose = ']',
            };
            return new SymbolContainer(provider);
        }
    }
}