using Microsoft.AspNetCore.Mvc;
using src.Backend.SMachine.API.DTOs;
using src.Backend.SMachine.API.Repositories;

namespace src.Backend.SMachine.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalcController : ControllerBase
    {
        private readonly IScoreRepository _scoreRepo;
        public CalcController(IScoreRepository scoreRepo)
        {
            _scoreRepo = scoreRepo;
        }

        /// <summary>
        /// Calculate Win-Lines
        /// </summary>
        /// <remarks>
        /// Sample Request:
        ///     POST /api/spin/start
        ///     {
        ///       "topLine": {
        ///         "leftSymbol": 0,
        ///         "centerSymbol": 0,
        ///         "rightSymbol": 0
        ///       },
        ///       "centerLine": {
        ///         "leftSymbol": 0,
        ///         "centerSymbol": 0,
        ///         "rightSymbol": 0
        ///       },
        ///       "bottomLine": {
        ///         "leftSymbol": 0,
        ///         "centerSymbol": 0,
        ///         "rightSymbol": 0
        ///       }
        ///     } 
        ///     
        /// </remarks>
        /// <param name="symbolMap">A symbol map with three win-lines</param>
        /// <response code="200">Return the score users won</response>
        [HttpPost("start")]
        public ActionResult<Score> Start(SymbolMap symbolMap)
        {
            return _scoreRepo.Calculate(symbolMap);
        }
    }
}