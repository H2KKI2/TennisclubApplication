using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub.Common.LeagueDTO;
using Tennisclub.DAL.Models;

namespace Tennisclub.DAL.Repositories.RepositorieInterfaces
{
    public interface ILeagueRepository : IGenericRepository<League, LeagueReadDto, object, object>
    {
    }
}
