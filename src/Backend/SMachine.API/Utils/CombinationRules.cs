using System.Collections.Generic;
using System.Linq;
using SMachine.API.Helpers;
using src.Backend.SMachine.API.DTOs;

namespace src.Backend.SMachine.API.Utils
{
    public class CombinationRules : IRules
    {
        private readonly WinLinesBuilder _winLines;
        private int _score;

        public CombinationRules(ref WinLinesBuilder builder)
        {
            _winLines = builder;
            _score = 0;
        }
        public int GetScore()
        {
            CherryAndSevenOnAnyLine();
            OneOrTwoBarsOnAnyLine();
            return _score;
        }

        // Return 75 score when cherry and seven on the same line
        private void CherryAndSevenOnAnyLine()
        {
            _score += SymbolHelpers.CherryAndSevenOnTheSameLine(_winLines.TopLine) ? 75 : 0;
            _score += SymbolHelpers.CherryAndSevenOnTheSameLine(_winLines.CenterLine) ? 75 : 0;
            _score += SymbolHelpers.CherryAndSevenOnTheSameLine(_winLines.BottomLine) ? 75 : 0;
        }


        // Return 5 score when one or two bars on any line
        private void OneOrTwoBarsOnAnyLine()
        {
            _score += SymbolHelpers.ABarOnTheLine(_winLines.TopLine) ? 5 : 0;
            _score += SymbolHelpers.ABarOnTheLine(_winLines.CenterLine) ? 5 : 0;
            _score += SymbolHelpers.ABarOnTheLine(_winLines.BottomLine) ? 5 : 0;
        }
    }
}