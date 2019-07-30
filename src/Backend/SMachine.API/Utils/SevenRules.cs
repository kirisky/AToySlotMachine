using System.Collections.Generic;
using System.Linq;
using SMachine.API.Helpers;
using src.Backend.SMachine.API.DTOs;

namespace src.Backend.SMachine.API.Utils
{
    public class SevenRules : IRules
    {
        private readonly WinLinesBuilder _WinLines;
        private int _score;

        public SevenRules(ref WinLinesBuilder builder)
        {
            _WinLines = builder;
            _score = 0;
        }

        public int GetScore()
        {
            ThreeSeventOnAnyLine();
            return _score;
        }

        // Return 150 score when 3 seven on any line
        private void ThreeSeventOnAnyLine()
        {
            _score += SymbolHelpers.ThreeSymbolsOnTheSameLine(_WinLines.TopLine, Symbol.Seven) ? 150 : 0;
            _score += SymbolHelpers.ThreeSymbolsOnTheSameLine(_WinLines.CenterLine, Symbol.Seven) ? 150 : 0;
            _score += SymbolHelpers.ThreeSymbolsOnTheSameLine(_WinLines.BottomLine, Symbol.Seven) ? 150 : 0;

        }

    }
}