using NUnit.Framework;
using src.Backend.SMachine.API.Utils;

namespace SMachine.API.Tests.Utils
{
    [TestFixture]
    public class BarRulesTests
    {
        private SymbolMapHelper _helper;

        [SetUp]
        public void SetUp()
        {
            _helper = new SymbolMapHelper();
        }

        [Test]
        public void GetScore_ThreeTripleBarsOnThreeLines_ReturnScore()
        {
            var builder = new WinLinesBuilder(_helper.SymbolMapWithThreeTripleBars);
            var rules = new BarRules(ref builder);
            var result = rules.GetScore();

            Assert.That(result, Is.EqualTo(150));
        }

        public void GetScore_ThreeDoubleBarsOnThreeLines_ReturnScore()
        {
            var builder = new WinLinesBuilder(_helper.SymbolMapWithThreeDoubleBars);
            var rules = new BarRules(ref builder);
            var result = rules.GetScore();

            Assert.That(result, Is.EqualTo(60));
        }

        public void GetScore_ThreeBarsOnThreeLines_ReturnScore()
        {
            var builder = new WinLinesBuilder(_helper.SymbolMapWithThreeBars);
            var rules = new BarRules(ref builder);
            var result = rules.GetScore();

            Assert.That(result, Is.EqualTo(30));
        }

       public void GetScore_CherryAndSevenOnThreeLines_ReturnZero()
        {
            var builder = new WinLinesBuilder(_helper.SymbolMapWithCherryAndSeven);
            var rules = new BarRules(ref builder);
            var result = rules.GetScore();

            Assert.That(result, Is.EqualTo(0));
        }
        
    }
}