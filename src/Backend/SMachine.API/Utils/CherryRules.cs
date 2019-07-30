using System.Collections.Generic;
using System.Linq;
using SMachine.API.Helpers;
using src.Backend.SMachine.API.DTOs;

namespace src.Backend.SMachine.API.Utils
{
    public class CherryRules : IRules
    {
        private int _score;
        private readonly WinLinesBuilder _winLines;

        public CherryRules(ref WinLinesBuilder winLineBuilder)
        {
            _score = 0;
            _winLines = winLineBuilder;
        }

        public int GetScore()
        {
            ThreeCherryOnTopLine();
            ThreeCherryOnCenterLine();
            ThreeCherryOnBottomLine();
            return _score;
        }
        
        // Return 2000 score when 3 cherry symbols on the top line
        private void ThreeCherryOnTopLine()
        {
            _score += SymbolHelpers.ThreeSymbolsOnTheSameLine(_winLines.TopLine, Symbol.Cherry) ? 2000 : 0;
        }

        // Return 1000 score when 3 cherry symbols on the center line
        private void ThreeCherryOnCenterLine()
        {
            _score += SymbolHelpers.ThreeSymbolsOnTheSameLine(_winLines.CenterLine, Symbol.Cherry) ? 1000 : 0;
        }

        // Return 4000 score when 3 cherry symbols on the bottom line
        private void ThreeCherryOnBottomLine()
        {
            _score += SymbolHelpers.ThreeSymbolsOnTheSameLine(_winLines.BottomLine, Symbol.Cherry) ? 4000 : 0;
        }

    }
}