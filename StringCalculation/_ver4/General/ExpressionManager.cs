using StringCalculation._ver4.Parsers.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculation._ver4.General
{
    public class ExpressionManager
    {
        private static ExpressionManager _instance;
        public static ExpressionManager Instance
        {
            get { if (_instance is null) _instance = new ExpressionManager();  return _instance; }
            set { if (value is null) _instance = value; }
        }

        public SymbolContainer SymbolsData { get;set; } = SymbolContainer.CreateDefault();
        public FunctionsContainer Functions { get; } = new FunctionsContainer();
        public ArgumentsContainer Arguments { get; } = new ArgumentsContainer();
        public IConstantParser ConstantParser { get; set; } = new CommonConstantParser();

        private ExpressionManager() { }
    }
}