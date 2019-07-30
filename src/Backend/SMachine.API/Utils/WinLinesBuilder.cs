using System.Collections.Generic;
using src.Backend.SMachine.API.DTOs;

namespace src.Backend.SMachine.API.Utils
{
    public class WinLinesBuilder 
    {
        public IList<Symbol> TopLine { get; }
        public IList<Symbol> CenterLine { get; }
        public IList<Symbol> BottomLine { get; }

        public WinLinesBuilder(SymbolMap symbolMap)
        {
            TopLine = new List<Symbol>();
            TopLine.Add(symbolMap.TopLine.LeftSymbol);
            TopLine.Add(symbolMap.TopLine.CenterSymbol);
            TopLine.Add(symbolMap.TopLine.RightSymbol);

            CenterLine = new List<Symbol>();
            CenterLine.Add(symbolMap.CenterLine.LeftSymbol);
            CenterLine.Add(symbolMap.CenterLine.CenterSymbol);
            CenterLine.Add(symbolMap.CenterLine.RightSymbol);

            BottomLine = new List<Symbol>();
            BottomLine.Add(symbolMap.BottomLine.LeftSymbol);
            BottomLine.Add(symbolMap.BottomLine.CenterSymbol);
            BottomLine.Add(symbolMap.BottomLine.RightSymbol);

        }

    }
}