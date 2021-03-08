using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub.Common.GameResultDTO;

namespace Tennisclub.BL.Services.ServiceInterfaces
{
    public interface IGameResultService
    {
        IEnumerable<GameResultReadDto> GetAllGameResults();
        IEnumerable<GameResultReadDto> GetGameResultsOfGame(int gameId);
        IEnumerable<GameResultReadDto> GetGameResultsFiltered(DateTime? date);
        GameResultReadDto AddGameResult(GameResultCreateDto gameResult);
        GameResultReadDto UpdateGameResult(GameResultUpdateDto gameResult);
    }
}
