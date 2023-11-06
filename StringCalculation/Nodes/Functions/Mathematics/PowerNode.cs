using System;
using System.Collections.Generic;

namespace StringCalculation.Nodes.Functions.Mathematics
{
    internal class PowerNode : FunctionNode
    {
        public PowerNode() : base(FunctionsInfo.POWER_FUNCTION_NAME, 2) { }

        private double GetNumberValue(List<double> args) => _nodes[0].Calculate(args);
        private double GetPowerValue(List<double> args) => _nodes[1].Calculate(args);

        internal override double Calculate(List<double> args) => Math.Pow(GetNumberValue(args), GetPowerValue(args));
    }
}
