using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tennisclub.BL.Services.ServiceInterfaces;
using Tennisclub.Common.GameResultDTO;

namespace Tennisclub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameResultsController : ControllerBase
    {
        private readonly IGameResultService _service;

        public GameResultsController(IGameResultService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<GameResultReadDto>> GetAllGameResults()
        {
            var gameResultItems = _service.GetAllGameResults();
            return Ok(gameResultItems);
        }

        [HttpGet]
        [Route("gameresultsofgame/{id}")]
        public ActionResult<IEnumerable<GameResultReadDto>> GetAllGameResultsOfGame(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Given Id is not valid");

                var gameResultsOfGameItems = _service.GetGameResultsOfGame(id);
                return Ok(gameResultsOfGameItems);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("filter")]
        public IEnumerable<GameResultReadDto> GetAllGameResultsFiltered([FromQuery] DateTime? date)
        {
            return _service.GetGameResultsFiltered(date);
        }

        [HttpPost("new")]
        public ActionResult<GameResultReadDto> AddGame(GameResultCreateDto gameResult)
        {
            try
            {
                if (gameResult == null)
                    return BadRequest("GameResult object is null");

                var newGameResult = _service.AddGameResult(gameResult);
                return Ok(newGameResult);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult UpdateGame(GameResultUpdateDto game)
        {
            try
            {
                if (game == null)
                    return BadRequest("Game object is null");

                _service.UpdateGameResult(game);
                return Ok("Game result is successfully updated");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
