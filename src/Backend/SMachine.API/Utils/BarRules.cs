using System.Collections.Generic;
using System.Linq;
using SMachine.API.Helpers;
using src.Backend.SMachine.API.DTOs;

namespace src.Backend.SMachine.API.Utils
{
    public class BarRules : IRules
    {
        private readonly WinLinesBuilder _winLines;
        private int _score;

        public BarRules(ref WinLinesBuilder builder)
        {
            _winLines = builder; 
            _score = 0;
        }

        public int GetScore()
        {
            ThreeTripleBarOnAnyLine();
            ThreeDoubleBarOnAnyLine();
            ThreeBarOnAnyLine();
            return _score;
        }

        // Return 50 score when three TripleBars on any line
        private void ThreeTripleBarOnAnyLine()
        {
            _score += SymbolHelpers.ThreeSymbolsOnTheSameLine(_winLines.TopLine, Symbol.TripleBar) ? 50 : 0;
            _score += SymbolHelpers.ThreeSymbolsOnTheSameLine(_winLines.CenterLine, Symbol.TripleBar) ? 50 : 0;
            _score += SymbolHelpers.ThreeSymbolsOnTheSameLine(_winLines.BottomLine, Symbol.TripleBar) ? 50 : 0;
        }

        // Return 20 score when three DoubleBars on any line
        private void ThreeDoubleBarOnAnyLine()
        {
            _score += SymbolHelpers.ThreeSymbolsOnTheSameLine(_winLines.TopLine, Symbol.DoubleBar) ? 20 : 0;
            _score += SymbolHelpers.ThreeSymbolsOnTheSameLine(_winLines.CenterLine, Symbol.DoubleBar) ? 20 : 0;
            _score += SymbolHelpers.ThreeSymbolsOnTheSameLine(_winLines.BottomLine, Symbol.DoubleBar) ? 20 : 0;
        }

        // Return 10 score when three Bars on any line
        private void ThreeBarOnAnyLine()
        {
            _score += SymbolHelpers.ThreeSymbolsOnTheSameLine(_winLines.TopLine, Symbol.Bar) ? 10 : 0;
            _score += SymbolHelpers.ThreeSymbolsOnTheSameLine(_winLines.CenterLine, Symbol.Bar) ? 10 : 0;
            _score += SymbolHelpers.ThreeSymbolsOnTheSameLine(_winLines.BottomLine, Symbol.Bar) ? 10 : 0;
        }

    }
}