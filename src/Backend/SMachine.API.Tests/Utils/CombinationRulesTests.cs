using NUnit.Framework;
using src.Backend.SMachine.API.Utils;

namespace SMachine.API.Tests.Utils
{
    [TestFixture]
    public class CombinationRulesTests
    {
        private SymbolMapHelper _helper;

        [SetUp]
        public void SetUp()
        {
            _helper = new SymbolMapHelper();
        }

        [Test]
        public void GetScore_CherryAndSevenOnThreeLines_ReturnScore()
        {
            var builder = new WinLinesBuilder(_helper.SymbolMapWithCherryAndSeven);
            var rules = new CombinationRules(ref builder);
            var result = rules.GetScore();

            Assert.That(result, Is.EqualTo(225));
        }

        [Test]
        public void GetScore_OneOrTwoBarsOnThreeLines_ReturnScore()
        {
            var builder = new WinLinesBuilder(_helper.SymbolMapWithOneOrTwoBars);
            var rules = new CombinationRules(ref builder);
            var result = rules.GetScore();

            Assert.That(result, Is.EqualTo(15));
        }

        [Test]
        public void GetScore_ThreeCherriesOnTheThreeLines_ReturnZero()
        {
            var builder = new WinLinesBuilder(_helper.SymbolMapWithThreeCherries);
            var rules = new CombinationRules(ref builder);
            var result = rules.GetScore();

            Assert.That(result, Is.EqualTo(0));
        }

    }
}