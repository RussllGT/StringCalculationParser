using StringCalculation.Calculation;
using StringCalculation.Parsers;
using StringCalculation.Parsers.Components;
using System.Collections.Generic;

namespace StringCalculation.General
{
    public class ExpressionManager
    {
        private static ExpressionManager _instance;
        public static ExpressionManager Instance
        {
            get { if (_instance is null) _instance = new ExpressionManager();  return _instance; }
            set { if (value is null) _instance = value; }
        }

        public IExpressionParser ExpressionParser { get; set; } = new CommonExpressionParser();
        public SymbolContainer SymbolsData { get;set; } = SymbolContainer.CreateDefault();
        public FunctionsContainer Functions { get; } = new FunctionsContainer();
        public ArgumentsContainer Arguments { get; } = new ArgumentsContainer();
        public IConstantParser ConstantParser { get; set; } = new CommonConstantParser();

        private ExpressionManager() { }

        public CalculationTree CreateTree(string expression, string[] arguments)
        {
            Arguments.AddRange(arguments);
            LinkedList<ICalculationNode> nodes = ExpressionParser.Parse(expression);
            CalculationTree result = CalculationTree.Create(nodes, Arguments.GetNames());
            return result;
        }
    }
}