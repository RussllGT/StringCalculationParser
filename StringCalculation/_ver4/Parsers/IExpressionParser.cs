﻿using StringCalculation._ver4.Calculation.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculation._ver4.Parsers
{
    public interface IExpressionParser
    {
        LinkedList<ICalculationNode> Parse(string expression);
    }
}
