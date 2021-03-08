using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub.Common.GameDTO;

namespace Tennisclub.BL.Services.ServiceInterfaces
{
    public interface IGameService
    {
        IEnumerable<GameReadDto> GetAllGames();
        IEnumerable<GameReadDto> GetGamesByMemberId(int memberId);
        IEnumerable<GameReadDto> GetGamesFiltered(DateTime? date);
        GameReadDto AddGame(GameCreateDto game);
        void UpdateGame(GameUpdateDto game);
        void DeleteGame(int id);
        
    }
}
