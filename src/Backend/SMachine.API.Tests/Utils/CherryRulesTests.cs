using NUnit.Framework;
using src.Backend.SMachine.API.Utils;

namespace SMachine.API.Tests.Utils
{
    [TestFixture]
    public class CherryRulesTests
    {
        private SymbolMapHelper _helper;

        [SetUp]
        public void SetUp()
        {
            _helper = new SymbolMapHelper();
        }

        [Test]
        public void GetScore_ThreeCherryiesOnTheThreeLines_ReturnScore()
        {
            var builder = new WinLinesBuilder(_helper.SymbolMapWithThreeCherries);
            var rules = new CherryRules(ref builder);
            var result = rules.GetScore();

            Assert.That(result, Is.EqualTo(7000));
        }

        [Test]
        public void GetScore_ThreeSevensOnTheThreeLines_ReturnZero()
        {
            var builder = new WinLinesBuilder(_helper.SymbolMapWithThreeSevens);
            var rules = new CherryRules(ref builder);
            var result = rules.GetScore();

            Assert.That(result, Is.EqualTo(0));
        }
    }
}