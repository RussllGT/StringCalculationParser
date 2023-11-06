using StringCalculation.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculation.Parsing.Elements
{
    internal interface IParsingElement
    {
        bool Check(char c, LinkedList<BaseNode> nodes);
        bool CheckEnd(LinkedList<BaseNode> nodes);
    }
}
