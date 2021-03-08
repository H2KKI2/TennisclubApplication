using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tennisclub.BL.Services.ServiceInterfaces;
using Tennisclub.Common.LeagueDTO;

namespace Tennisclub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaguesController : ControllerBase
    {
        private readonly ILeagueService _service;

        public LeaguesController(ILeagueService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<LeagueReadDto>> GetAllLeagues()
        {
            var leaguerItems = _service.GetAllLeagues();
            return Ok(leaguerItems);
        }
    }
}
