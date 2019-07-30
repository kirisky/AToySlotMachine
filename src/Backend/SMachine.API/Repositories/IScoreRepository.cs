using src.Backend.SMachine.API.DTOs;

namespace src.Backend.SMachine.API.Repositories
{
    public interface IScoreRepository
    {
         Score Calculate (SymbolMap map);
    }
}