using System;
using src.Backend.SMachine.API.DTOs;

namespace SMachine.API.Tests
{
    public class SymbolMapHelper
    {
        public SymbolMap SymbolMapWithThreeCherries
        {
            get
            {
                return GeneratedSpecificSymbolMap(
                    new SymbolSet
                    {
                        TopLeft = Symbol.Cherry,
                        TopCenter = Symbol.Cherry,
                        TopRight = Symbol.Cherry,
                        CenterLeft = Symbol.Cherry,
                        CenterCenter = Symbol.Cherry,
                        CenterRight = Symbol.Cherry,
                        BottomLeft = Symbol.Cherry,
                        BottomCenter = Symbol.Cherry,
                        BottomRight = Symbol.Cherry
                    }
                );
            }
        }


        public SymbolMap SymbolMapWithThreeSevens
        {
            get
            {
                return GeneratedSpecificSymbolMap(
                    new SymbolSet
                    {
                        TopLeft = Symbol.Seven,
                        TopCenter = Symbol.Seven,
                        TopRight = Symbol.Seven,
                        CenterLeft = Symbol.Seven,
                        CenterCenter = Symbol.Seven,
                        CenterRight = Symbol.Seven,
                        BottomLeft = Symbol.Seven,
                        BottomCenter = Symbol.Seven,
                        BottomRight = Symbol.Seven
                    }
                );
            }
        }
        public SymbolMap SymbolMapWithThreeTripleBars
        {
            get
            {
                return GeneratedSpecificSymbolMap(
                    new SymbolSet
                    {
                        TopLeft = Symbol.TripleBar,
                        TopCenter = Symbol.TripleBar,
                        TopRight = Symbol.TripleBar,
                        CenterLeft = Symbol.TripleBar,
                        CenterCenter = Symbol.TripleBar,
                        CenterRight = Symbol.TripleBar,
                        BottomLeft = Symbol.TripleBar,
                        BottomCenter = Symbol.TripleBar,
                        BottomRight = Symbol.TripleBar
                    }
                );
            }
        }

        public SymbolMap SymbolMapWithThreeDoubleBars
        {
            get
            {
                return GeneratedSpecificSymbolMap(
                    new SymbolSet
                    {
                        TopLeft = Symbol.DoubleBar,
                        TopCenter = Symbol.DoubleBar,
                        TopRight = Symbol.DoubleBar,
                        CenterLeft = Symbol.DoubleBar,
                        CenterCenter = Symbol.DoubleBar,
                        CenterRight = Symbol.DoubleBar,
                        BottomLeft = Symbol.DoubleBar,
                        BottomCenter = Symbol.DoubleBar,
                        BottomRight = Symbol.DoubleBar
                    }
                );
            }
        }

        public SymbolMap SymbolMapWithThreeBars
        {
            get
            {
                return GeneratedSpecificSymbolMap(
                    new SymbolSet
                    {
                        TopLeft = Symbol.Bar,
                        TopCenter = Symbol.Bar,
                        TopRight = Symbol.Bar,
                        CenterLeft = Symbol.Bar,
                        CenterCenter = Symbol.Bar,
                        CenterRight = Symbol.Bar,
                        BottomLeft = Symbol.Bar,
                        BottomCenter = Symbol.Bar,
                        BottomRight = Symbol.Bar
                    }
                );
            }
        }

        public SymbolMap SymbolMapWithCherryAndSeven
        {
            get
            {
                return GeneratedSpecificSymbolMap(
                    new SymbolSet
                    {
                        TopLeft = Symbol.Cherry,
                        TopCenter = Symbol.Bar,
                        TopRight = Symbol.Seven,
                        CenterLeft = Symbol.Seven,
                        CenterCenter = Symbol.Cherry,
                        CenterRight = Symbol.Bar,
                        BottomLeft = Symbol.Bar,
                        BottomCenter = Symbol.Seven,
                        BottomRight = Symbol.Cherry
                    }
                );
            }
        }

        public SymbolMap SymbolMapWithMixSymbols
        {
            get
            {
                return GeneratedSpecificSymbolMap(
                    new SymbolSet
                    {
                        // 5 score
                        TopLeft = Symbol.Bar,
                        TopCenter = Symbol.TripleBar,
                        TopRight = Symbol.None,
                        // 75 score
                        CenterLeft = Symbol.Cherry,
                        CenterCenter = Symbol.Seven,
                        CenterRight = Symbol.Bar,
                        // 0 score
                        BottomLeft = Symbol.Cherry,
                        BottomCenter = Symbol.DoubleBar,
                        BottomRight = Symbol.TripleBar
                    }
                );
            }
        }

        public SymbolMap SymbolMapWithOneOrTwoBars
        {
            get
            {
                return GeneratedSpecificSymbolMap(
                    new SymbolSet
                    {
                        // 5 score
                        TopLeft = Symbol.Bar,
                        TopCenter = Symbol.TripleBar,
                        TopRight = Symbol.None,
                        // 75 score
                        CenterLeft = Symbol.DoubleBar,
                        CenterCenter = Symbol.Seven,
                        CenterRight = Symbol.Bar,
                        // 0 score
                        BottomLeft = Symbol.Cherry,
                        BottomCenter = Symbol.Bar,
                        BottomRight = Symbol.TripleBar
                    }
                );
            }
        }
        public SymbolMap SymbolMapWithNone
        {
            get
            {
                return GeneratedSpecificSymbolMap(
                    new SymbolSet
                    {
                        // 5 score
                        TopLeft = Symbol.None,
                        TopCenter = Symbol.None,
                        TopRight = Symbol.None,
                        // 75 + 5 score
                        CenterLeft = Symbol.None,
                        CenterCenter = Symbol.None,
                        CenterRight = Symbol.None,
                        // 0 score
                        BottomLeft = Symbol.None,
                        BottomCenter = Symbol.None,
                        BottomRight = Symbol.None
                    }
                );
            }
        }

        public SymbolMap SymbolMapWithAnUnavailableSymbolType
        {
            get
            {
                return GeneratedSpecificSymbolMap(
                    new SymbolSet
                    {
                        TopLeft = (Symbol) 6,
                        TopCenter = Symbol.Cherry,
                        TopRight = Symbol.Cherry,
                        CenterLeft = Symbol.Cherry,
                        CenterCenter = Symbol.Cherry,
                        CenterRight = Symbol.Cherry,
                        BottomLeft = Symbol.Cherry,
                        BottomCenter = Symbol.Cherry,
                        BottomRight = Symbol.Cherry
                    }
                );
            }
        }

        private SymbolMap GeneratedSpecificSymbolMap(SymbolSet symbolSet)
        {
            return new SymbolMap
            {
                TopLine = new WinLine
                {
                    LeftSymbol = symbolSet.TopLeft,
                    CenterSymbol = symbolSet.TopCenter,
                    RightSymbol = symbolSet.TopRight
                },
                CenterLine = new WinLine
                {
                    LeftSymbol = symbolSet.CenterLeft,
                    CenterSymbol = symbolSet.CenterCenter,
                    RightSymbol = symbolSet.CenterRight
                },
                BottomLine = new WinLine
                {
                    LeftSymbol = symbolSet.BottomLeft,
                    CenterSymbol = symbolSet.BottomCenter,
                    RightSymbol = symbolSet.BottomRight
                },
            };
        }

        class SymbolSet
        {
            public Symbol TopLeft { get; set; }
            public Symbol TopCenter { get; set; }
            public Symbol TopRight { get; set; }
            public Symbol CenterLeft { get; set; }
            public Symbol CenterCenter { get; set; }
            public Symbol CenterRight { get; set; }
            public Symbol BottomLeft { get; set; }
            public Symbol BottomCenter { get; set; }
            public Symbol BottomRight { get; set; }
        }
    }
}