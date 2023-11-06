using System.Collections.Generic;

namespace StringCalculation.Nodes.Functions
{
    internal static class FunctionsInfo
    {
        internal const string POWER_FUNCTION_NAME = "Pow";

        private readonly static List<string> _functionNames = new List<string>()
        {
            POWER_FUNCTION_NAME,
        };

        internal static IEnumerable<string> FunctionNames => _functionNames;
    }
}