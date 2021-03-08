using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tennisclub.Common.GameResultDTO;
using Tennisclub.DAL.Data;
using Tennisclub.DAL.Models;
using Tennisclub.DAL.Repositories.RepositorieInterfaces;

namespace Tennisclub.DAL.Repositories
{
    public class GameResultRepository : GenericRepository<GameResult, GameResultReadDto, GameResultCreateDto, GameResultUpdateDto>, IGameResultRepository
    {
        public GameResultRepository(TennisclubContext context, IMapper mapper)
            :base(context, mapper)
        { }

        public override IEnumerable<GameResultReadDto> GetAll()
        {
            return _mapper.Map<IEnumerable<GameResultReadDto>>(_dbSet.AsNoTracking().Include(gr => gr.Game).ThenInclude(g => g.Member).Include(gr => gr.Game).ThenInclude(g => g.League));
        }

        public override GameResultReadDto GetById(int id)
        {
            if (id < 1) throw new ArgumentOutOfRangeException("Items can not have an id below 1.");

            return _mapper.Map<GameResultReadDto>(_dbSet.Include(gr => gr.Game).FirstOrDefault(gr => gr.Id == id));
        }

        public override IEnumerable<GameResultReadDto> GetAllFiltered(Func<GameResult, bool> filter)
        {
            return _mapper.Map<IEnumerable<GameResultReadDto>>(_dbSet.AsNoTracking().Include(m => m.Game).Where(filter).ToList());
        }

        public override List<GameResult> _GetAll()
        {
            return _dbSet.AsNoTracking().Include(gr => gr.Game).ThenInclude(g => g.Member).ToList();
        }

        public IEnumerable<GameResultReadDto> GetResultsOfGame(int gameId)
        {
            return _mapper.Map<IEnumerable<GameResultReadDto>>(_dbSet.AsNoTracking().Include(gr => gr.Game).ThenInclude(g => g.League).Where(g => g.GameId == gameId));
        }

        public override GameResultReadDto Update(GameResultUpdateDto item)
        {
            int id = item.Id;
            GameResult updatedGameResult = _dbSet.Find(id);

            if (updatedGameResult == null)
                throw new NullReferenceException("Game result with this id is not found");

            updatedGameResult.SetNr = item.SetNr;
            updatedGameResult.ScoreTeamMember = item.ScoreTeamMember;
            updatedGameResult.ScoreOpponent = item.ScoreOpponent;

            _context.Entry(updatedGameResult).Property(mf => mf.SetNr).IsModified = true;
            _context.Entry(updatedGameResult).Property(mf => mf.ScoreTeamMember).IsModified = true;
            _context.Entry(updatedGameResult).Property(mf => mf.ScoreOpponent).IsModified = true;
            Save();

            return _mapper.Map<GameResultReadDto>(updatedGameResult);
        }
    }
}
