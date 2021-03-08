using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub.Common.LeagueDTO;
using Tennisclub.DAL.Data;
using Tennisclub.DAL.Models;
using Tennisclub.DAL.Repositories.RepositorieInterfaces;

namespace Tennisclub.DAL.Repositories
{
    public class LeagueRepository : GenericRepository<League, LeagueReadDto, object, object>, ILeagueRepository
    {
        public LeagueRepository(TennisclubContext context, IMapper mapper)
            : base(context,mapper)
        { }

        public override IEnumerable<LeagueReadDto> GetAll()
        {
            return _mapper.Map<IEnumerable<LeagueReadDto>>(_context.Leagues.FromSqlRaw("SELECT * FROM dbo.Leagues ORDER BY Id"));
        }
    }
}
