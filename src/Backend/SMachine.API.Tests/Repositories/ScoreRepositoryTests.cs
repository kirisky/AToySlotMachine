using NUnit.Framework;
using SMachine.API.Tests.Helpers;
using src.Backend.SMachine.API.DTOs;
using src.Backend.SMachine.API.Repositories;

namespace SMachine.API.Tests.Repositories
{
    [TestFixture]
    public class ScoreRepositoryTests
    {
        private ScoreRepository _scoreRepo;
        private SymbolMapHelper _symbolMapHelper;

        [SetUp]
        public void SetUp()
        {
            _scoreRepo = new ScoreRepository();            
            _symbolMapHelper = new SymbolMapHelper();
        }

        [Test] 
        public void Calculate_ThreeCherriesOnThreeLines_ReturnScore()
        {
            Assert.That(
                _scoreRepo.Calculate(_symbolMapHelper.SymbolMapWithThreeCherries).Value,
                Is.EqualTo(7000));
        }

        [Test] 
        public void Calculate_ThreeSevensOnThreeLines_ReturnScore()
        {
            Assert.That(
                _scoreRepo.Calculate(_symbolMapHelper.SymbolMapWithThreeSevens).Value,
                Is.EqualTo(450));
        }


        [Test] 
        public void Calculate_ThreeTripleBarsOnThreeLines_ReturnScore()
        {
            Assert.That(
                _scoreRepo.Calculate(_symbolMapHelper.SymbolMapWithThreeTripleBars).Value,
                Is.EqualTo(150));
        }

        [Test] 
        public void Calculate_ThreeDoubleBarsOnThreeLines_ReturnScore()
        {
            Assert.That(
                _scoreRepo.Calculate(_symbolMapHelper.SymbolMapWithThreeDoubleBars).Value,
                Is.EqualTo(60));
        }

        [Test] 
        public void Calculate_ThreeBarsOnThreeLines_ReturnScore()
        {
            Assert.That(
                _scoreRepo.Calculate(_symbolMapHelper.SymbolMapWithThreeBars).Value,
                Is.EqualTo(30));
        }

        [Test]
        public void Calculate_CherryAndSevenOnThreeLines_ReturnScore()
        {
            Assert.That(
                _scoreRepo.Calculate(_symbolMapHelper.SymbolMapWithCherryAndSeven).Value,
                Is.EqualTo(225));
        }

        [Test] 
        public void Calculate_MixSymbolsOnThreeLines_ReturnScore()
        {
            Assert.That(
                _scoreRepo.Calculate(_symbolMapHelper.SymbolMapWithMixSymbols).Value,
                Is.EqualTo(80));
        }

        [Test]
        public void Calculate_TakeNonWinningSymbols_ReturnZero()
        {
            Assert.That(
                _scoreRepo.Calculate(_symbolMapHelper.SymbolMapWithNone).Value,
                Is.EqualTo(0));
        }
    }
}