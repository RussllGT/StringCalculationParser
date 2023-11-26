using StringCalculation._ver4.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculation._ver4.Calculation.Nodes
{
    public interface ICalculationNode
    {
        ValueNode4 Calculate();
        void RegisterInTree(CalculationTree4 tree);
    }
}