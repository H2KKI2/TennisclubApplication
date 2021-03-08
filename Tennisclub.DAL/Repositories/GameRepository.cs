using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tennisclub.Common.GameDTO;
using Tennisclub.DAL.Data;
using Tennisclub.DAL.Models;
using Tennisclub.DAL.Repositories.RepositorieInterfaces;

namespace Tennisclub.DAL.Repositories
{
    public class GameRepository : GenericRepository<Game, GameReadDto, GameCreateDto, GameUpdateDto>, IGameRepository
    {
        public GameRepository(TennisclubContext context, IMapper mapper)
            : base(context, mapper)
        { }

        public IEnumerable<GameReadDto> GetGamesByMemberId(int memberId)
        {
            return _mapper.Map<IEnumerable<GameReadDto>>(_dbSet.AsNoTracking().Include(g => g.League).Where(g => g.MemberId == memberId));
        }

        public override List<Game> _GetAll()
        {
            return _dbSet.AsNoTracking().Include(g => g.League).Include(g => g.Member).ToList();
        }

        public override GameReadDto Update(GameUpdateDto item)
        {
            int id = item.Id;
            Game updatedGame = _dbSet.Find(id);

            if (updatedGame == null)
                throw new NullReferenceException("Game with this id is not found");

            updatedGame.GameNumber = item.GameNumber;
            updatedGame.LeagueId = item.LeagueId;
            updatedGame.Date = item.Date;

            _context.Entry(updatedGame).Property(mf => mf.GameNumber).IsModified = true;
            _context.Entry(updatedGame).Property(mf => mf.LeagueId).IsModified = true;
            _context.Entry(updatedGame).Property(mf => mf.Date).IsModified = true;
            Save();

            return _mapper.Map<GameReadDto>(updatedGame);
        }
    }
}
