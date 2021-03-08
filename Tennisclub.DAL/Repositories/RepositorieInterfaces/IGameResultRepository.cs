using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub.Common.GameResultDTO;
using Tennisclub.DAL.Models;

namespace Tennisclub.DAL.Repositories.RepositorieInterfaces
{
    public interface IGameResultRepository : IGenericRepository<GameResult, GameResultReadDto, GameResultCreateDto, GameResultUpdateDto>
    {
        IEnumerable<GameResultReadDto> GetResultsOfGame(int gameId);
    }
}
