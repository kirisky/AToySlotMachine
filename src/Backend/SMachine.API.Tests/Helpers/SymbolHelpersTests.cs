using System.Collections.Generic;
using NUnit.Framework;
using SMachine.API.Helpers;
using src.Backend.SMachine.API.DTOs;

namespace SMachine.API.Tests.Helpers
{
    [TestFixture]
    public class SymbolHelpersTests
    {
        [Test]   
        public void ThreeSymbolsOnTheSameLine_ThreeCherriesOnTheSameLine_ReturnTrue()
        {
            var aLine = GenerateALine(Symbol.Cherry, Symbol.Cherry, Symbol.Cherry);
            var result = SymbolHelpers.ThreeSymbolsOnTheSameLine(aLine, Symbol.Cherry);
            
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]   
        public void ThreeSymbolsOnTheSameLine_ThreeDiffirentSymbosOnTheSameLine_ReturnFalse()
        {
            var aLine = GenerateALine(Symbol.Seven, Symbol.Cherry, Symbol.DoubleBar);
            var result = SymbolHelpers.ThreeSymbolsOnTheSameLine(aLine, Symbol.Cherry);

            Assert.That(result, Is.EqualTo(false));
        }

        [Test]   
        public void CherryAndSevenOnTheSameLine_CherryAndSevenOnTheSameLine_ReturnTrue()
        {
            var aLine = GenerateALine(Symbol.Cherry, Symbol.Seven, Symbol.TripleBar);
            var result = SymbolHelpers.CherryAndSevenOnTheSameLine(aLine);

            Assert.That(result, Is.EqualTo(true));
        }

        [Test]   
        public void CherryAndSevenOnTheSameLine_NoCherryAndSevenOnTheSameLine_ReturnFalse()
        {
            var aLine = GenerateALine(Symbol.TripleBar, Symbol.DoubleBar, Symbol.DoubleBar);
            var result = SymbolHelpers.CherryAndSevenOnTheSameLine(aLine);

            Assert.That(result, Is.EqualTo(false));
        }

        [Test]   
        public void ABarOnTheLine_ABarOnTheLine_ReturnTrue()
        {
            var aLine = GenerateALine(Symbol.Bar, Symbol.DoubleBar, Symbol.TripleBar);
            var result = SymbolHelpers.ABarOnTheLine(aLine);

            Assert.That(result, Is.EqualTo(true));
        }

        [Test]   
        public void ABarOnTheLine_NoBarOnTheLine_ReturnFalse()
        {
            var aLine = GenerateALine(Symbol.DoubleBar, Symbol.TripleBar, Symbol.Seven);
            var result = SymbolHelpers.ABarOnTheLine(aLine);

            Assert.That(result, Is.EqualTo(false));
        }

        private IList<Symbol> GenerateALine(Symbol first, Symbol second, Symbol third)
        {
            var aLine = new List<Symbol>();
            aLine.AddRange(new Symbol[] { first, second, third });

            return aLine;
        }

    }
}