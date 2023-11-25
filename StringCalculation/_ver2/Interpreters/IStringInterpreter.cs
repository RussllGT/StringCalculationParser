using StringCalculation.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculation._ver2.Interpreters
{
    internal interface IStringInterpreter
    {
        bool AddSymbol(char symbol);
        BaseNode GetNode();
    }
}
