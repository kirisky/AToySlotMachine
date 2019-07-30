using NUnit.Framework;
using src.Backend.SMachine.API.Utils;

namespace SMachine.API.Tests.Utils
{
    [TestFixture]
    public class SevenRulesTests
    {
        private SymbolMapHelper _helper;

        [SetUp]
        public void SetUp()
        {
            _helper = new SymbolMapHelper();
        }

        [Test]
        public void GetScore_ThreeSevensOnTheThreeLines_ReturnScore()
        {
            var builder = new WinLinesBuilder(_helper.SymbolMapWithThreeSevens);
            var rules = new SevenRules(ref builder);
            var result = rules.GetScore();

            Assert.That(result, Is.EqualTo(450));
        }

        [Test]
        public void GetScore_ThreeCherriesOnTheThreeLines_ReturnZero()
        {
            var builder = new WinLinesBuilder(_helper.SymbolMapWithThreeCherries);
            var rules = new SevenRules(ref builder);
            var result = rules.GetScore();

            Assert.That(result, Is.EqualTo(0));
        }
    }
}