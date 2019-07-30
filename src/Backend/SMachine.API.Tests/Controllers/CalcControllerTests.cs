using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using src.Backend.SMachine.API.Controllers;
using src.Backend.SMachine.API.DTOs;
using src.Backend.SMachine.API.Repositories;

namespace SMachine.API.Tests.Controllers
{
    [TestFixture]
    public class CalcControllerTests
    {
        private Mock<IScoreRepository> _mockRepo;
        private CalcController _calcController;
        private SymbolMapHelper _helper;

        [SetUp]
        public void Setup()
        {
            _helper = new SymbolMapHelper();

            _mockRepo = new Mock<IScoreRepository>();
            _calcController = new CalcController(_mockRepo.Object);
        }

        [Test]
        public void Start_ThreeCherriesOnThreeLines_ReturnScore()
        {
            var symbolMap = _helper.SymbolMapWithThreeCherries;
            _mockRepo.Setup(repo => repo.Calculate(symbolMap))
                .Returns(new Score { Value = 7000 });

            var actionResult = _calcController.Start(symbolMap);
            var result = actionResult.Value;

            _mockRepo.Verify(s => s.Calculate(symbolMap));
            Assert.That(actionResult, Is.InstanceOf(typeof(ActionResult<Score>)));
            Assert.That(result, Is.InstanceOf(typeof(Score)));
            Assert.That(result.Value, Is.EqualTo(7000));

        }
    }
}