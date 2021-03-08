using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub.BL.Services.ServiceInterfaces;
using Tennisclub.Common.LeagueDTO;
using Tennisclub.DAL.Repositories.RepositorieInterfaces;

namespace Tennisclub.BL.Services
{
    public class LeagueService : ILeagueService
    {
        private readonly ILeagueRepository _repository;

        public LeagueService(ILeagueRepository repository)
        {
            _repository = repository;
        }
        public IEnumerable<LeagueReadDto> GetAllLeagues()
        {
            return _repository.GetAll();
        }
    }
}
