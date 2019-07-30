using System.Collections.Generic;
using System.Linq;
using src.Backend.SMachine.API.DTOs;

namespace SMachine.API.Helpers
{
    public class SymbolHelpers
    {
        public static bool ThreeSymbolsOnTheSameLine(IList<Symbol> winLine, Symbol symbolType)
        {
            if (IsEmptyOrNull(winLine)) return false;

            if (!winLine.All<Symbol>(s => s == symbolType)) return false;
            
            winLine.Clear();
            return true;
        } 

        public static bool CherryAndSevenOnTheSameLine(IList<Symbol> winLine)
        {
            if (IsEmptyOrNull(winLine)) return false;

            if (!(winLine.Any(s => s == Symbol.Cherry) && winLine.Any(s => s == Symbol.Seven))) return false;

            winLine.Clear();
            return true;
        }

        public static bool ABarOnTheLine(IList<Symbol> winLine)
        {
            if (IsEmptyOrNull(winLine)) return false;

            return winLine.Contains(Symbol.Bar);
        }

        private static bool IsEmptyOrNull(IList<Symbol> winLine)
        {
            var isNull = winLine == null;
            var isEmpty = !winLine.Any();

            if (isNull || isEmpty) return true;

            return false;
        }
    }
}