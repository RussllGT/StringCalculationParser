using StringCalculation.Nodes;
using StringCalculation.Nodes.Functions;
using StringCalculation.Nodes.Functions.Mathematics;
using StringCalculation.Nodes.Operations.Low;
using StringCalculation.Parsing.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculation.Parsing.Elements
{
    internal class FunctionParser : IParsingElement
    {
        private string _functionName = string.Empty;
        private bool _isActive = false;

        public bool Check(char c, LinkedList<BaseNode> nodes)
        {
            bool result = true;
            _functionName += c;
            if (_isActive)
            {
               
                if (GetFunction() is FunctionNode node)
                {
                    nodes.AddLast(node);
                    _functionName = string.Empty;
                    _isActive = false;
                }
                if (IsIncorrectFunctionName())
                {
                    _functionName = string.Empty;
                    throw new ArgumentException($"Inccorrect function name starts with \"{_functionName}\"");
                }
                    
            }
            else
            {
                if (IsIncorrectFunctionName())
                {
                    _functionName = string.Empty;
                    result = false;
                }
                else
                {
                    _isActive = true;
                }
            }
            return result;
        }

        public bool CheckEnd(LinkedList<BaseNode> nodes) => false;

        private FunctionNode GetFunction()
        {
            switch (_functionName)
            {
                case FunctionsInfo.POWER_FUNCTION_NAME:
                    return new PowerNode();

                default: 
                    return null;
            }
        }

        private bool IsIncorrectFunctionName()
        {
            foreach (string fName in FunctionsInfo.FunctionNames)
            {
                if (fName.StartsWith(_functionName)) return false;
            }
            return true;
        }
    }
}
