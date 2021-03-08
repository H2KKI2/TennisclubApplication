using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub.Common.LeagueDTO;

namespace Tennisclub.BL.Services.ServiceInterfaces
{
    public interface ILeagueService
    {
        IEnumerable<LeagueReadDto> GetAllLeagues();
    }
}
