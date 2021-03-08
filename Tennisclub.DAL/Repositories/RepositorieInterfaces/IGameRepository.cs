using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub.Common.GameDTO;
using Tennisclub.DAL.Models;

namespace Tennisclub.DAL.Repositories.RepositorieInterfaces
{
    public interface IGameRepository : IGenericRepository<Game, GameReadDto, GameCreateDto, GameUpdateDto>
    {
        IEnumerable<GameReadDto> GetGamesByMemberId(int memberId);
    }
}
