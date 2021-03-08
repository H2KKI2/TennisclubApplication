using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tennisclub.BL.Services.ServiceInterfaces;
using Tennisclub.Common.GameResultDTO;
using Tennisclub.DAL.Models;
using Tennisclub.DAL.Repositories.RepositorieInterfaces;

namespace Tennisclub.BL.Services
{
    public class GameResultService : IGameResultService
    {
        private readonly IGameResultRepository _repository;

        public GameResultService(IGameResultRepository repository)
        {
            _repository = repository;
        }
        public GameResultReadDto AddGameResult(GameResultCreateDto gameResult)
        {
            GameResultCheck(gr => gr.GameId == gameResult.GameId && gr.SetNr == gameResult.SetNr);
            return _repository.Add(gameResult);
        }

        public IEnumerable<GameResultReadDto> GetAllGameResults()
        {
            return _repository.GetAll();
        }

        public IEnumerable<GameResultReadDto> GetGameResultsFiltered(DateTime? date)
        {
            return _repository.GetAllFiltered(gr => (gr.Game.Date == date || gr.Game.Date == null));
        }

        public IEnumerable<GameResultReadDto> GetGameResultsOfGame(int gameId)
        {
            return _repository.GetResultsOfGame(gameId);
        }

        public GameResultReadDto UpdateGameResult(GameResultUpdateDto gameResult)
        {
            GameResultUpdateCheck(gameResult);
            return _repository.Update(gameResult);
        }

        private void GameResultCheck(Func<GameResult, bool> filter)
        {
            IEnumerable<GameResultReadDto> listGameResuls = _repository.GetAllFiltered(filter);
            if (listGameResuls.Count() != 0)
                throw new ArgumentException("Game result is not unique");
        }

        private void GameResultUpdateCheck(GameResultUpdateDto gameResult)
        {
            IEnumerable<GameResultReadDto> listGameResults = _repository.GetAllFiltered(gr => gr.SetNr == gameResult.SetNr && gr.Id != gameResult.Id);
            if (listGameResults.Count() != 0)
                throw new ArgumentException("Game result is not unique");
        }
    }
}
