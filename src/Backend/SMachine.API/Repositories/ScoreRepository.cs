using src.Backend.SMachine.API.DTOs;
using src.Backend.SMachine.API.Utils;

namespace src.Backend.SMachine.API.Repositories
{
    public class ScoreRepository : IScoreRepository
    {
        public Score Calculate(SymbolMap map)
        {
            var score = 0;

            var winLinesBuilder = new WinLinesBuilder(map);
            score += new CherryRules(ref winLinesBuilder).GetScore();
            score += new SevenRules(ref winLinesBuilder).GetScore();
            score += new BarRules(ref winLinesBuilder).GetScore();
            score += new CombinationRules(ref winLinesBuilder).GetScore();

            return new Score {
                Value = score
            };
        }
    }
}