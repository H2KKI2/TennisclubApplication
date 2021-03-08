using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tennisclub.BL.Services.ServiceInterfaces;
using Tennisclub.Common.GameDTO;
using Tennisclub.DAL.Models;
using Tennisclub.DAL.Repositories.RepositorieInterfaces;

namespace Tennisclub.BL.Services
{
    class GameService : IGameService
    {
        const int GAME_NUMBER_MAX_LENGTH = 10;

        private readonly IGameRepository _repository;

        public GameService(IGameRepository repository)
        {
            _repository = repository;
        }

        public GameReadDto AddGame(GameCreateDto game)
        {
            ValidationCheck(game.GameNumber);
            MemberFineCheck(g => g.GameNumber == game.GameNumber);
            return _repository.Add(game);
        }

        public void DeleteGame(int id)
        {
            _repository.Delete(id);
        }

        public IEnumerable<GameReadDto> GetAllGames()
        {
            return _repository.GetAll();
        }

        public IEnumerable<GameReadDto> GetGamesByMemberId(int memberId)
        {
            return _repository.GetGamesByMemberId(memberId);
        }

        public IEnumerable<GameReadDto> GetGamesFiltered(DateTime? date)
        {
            return _repository.GetAllFiltered(game => (game.Date == date || game.Date == null));
        }

        public void UpdateGame(GameUpdateDto game)
        {
            ValidationCheck(game.GameNumber);
            MemberFineCheck(g => g.GameNumber == game.GameNumber && g.Id != game.Id);
            _repository.Update(game);
        }

        private void ValidationCheck(string gameNumber)
        {
            if (gameNumber.Length > GAME_NUMBER_MAX_LENGTH)
                throw new ArgumentException($"Game number cannot be longer than {GAME_NUMBER_MAX_LENGTH}");
        }

        private void MemberFineCheck(Func<Game, bool> filter)
        {
            IEnumerable<GameReadDto> listGames = _repository.GetAllFiltered(filter);
            if (listGames.Count() != 0)
                throw new ArgumentException("Game is not unique");
        }

    }
}
