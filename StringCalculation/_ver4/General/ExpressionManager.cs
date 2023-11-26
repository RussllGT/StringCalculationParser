using StringCalculation._ver4.Calculation;
using StringCalculation._ver4.Calculation.Nodes;
using StringCalculation._ver4.Parsers;
using StringCalculation._ver4.Parsers.Components;
using StringCalculation.Nodes;
using StringCalculation.Nodes.Functions;
using StringCalculation.Nodes.Operations;
using StringCalculation.Nodes.Operations.Low;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

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

        public IExpressionParser ExpressionParser { get; set; } = new CommonExpressionParser();
        public SymbolContainer SymbolsData { get;set; } = SymbolContainer.CreateDefault();
        public FunctionsContainer Functions { get; } = new FunctionsContainer();
        public ArgumentsContainer Arguments { get; } = new ArgumentsContainer();
        public IConstantParser ConstantParser { get; set; } = new CommonConstantParser();

        private ExpressionManager() { }

        public CalculationTree4 CreateTree(string expression, string[] arguments)
        {
            Arguments.AddRange(arguments);
            LinkedList<ICalculationNode> nodes = ExpressionParser.Parse(expression);
            CalculationTree4 result = CalculationTree4.Create(nodes, Arguments.GetNames());
            return result;
        }
    }
}