﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculation._ver4.Parsers.Readers
{
    public interface ISymbolReader
    {
        SymbolReadingInfo ReadSymbol(char symbol);
    }
}