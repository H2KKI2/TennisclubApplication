using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tennisclub.BL.Services.ServiceInterfaces;
using Tennisclub.Common.GameDTO;

namespace Tennisclub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGameService _service;

        public GamesController(IGameService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<GameReadDto>> GetAllGames()
        {
            var gameItems = _service.GetAllGames();
            return Ok(gameItems);
        }

        [HttpGet]
        [Route("gamesofmember/{id}")]
        public ActionResult<IEnumerable<GameReadDto>> GetAllGamesOfMember(int id)
        {
            try
            {
                if(id <= 0)
                    return BadRequest("Given Id is not valid");

                var gamesOfMemberItems = _service.GetGamesByMemberId(id);
                return Ok(gamesOfMemberItems);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("filter")]
        public IEnumerable<GameReadDto> GetAllGamesFiltered([FromQuery] DateTime? date)
        {
            return _service.GetGamesFiltered(date);
        }

        [HttpPost("new")]
        public ActionResult<GameReadDto> AddGame(GameCreateDto game)
        {
            try
            {
                if (game == null)
                    return BadRequest("Game object is null");

                var newGame = _service.AddGame(game);
                return Ok(newGame);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult UpdateGame(GameUpdateDto game)
        {
            try
            {
                if (game == null)
                    return BadRequest("Game object is null");

                _service.UpdateGame(game);
                return Ok("Game is successfully updated");

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteGame(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Given Id is not valid");

                _service.DeleteGame(id);
            return Ok("Game is successfully updated");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
