using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        IGameService _gameService;
        public GameController(IGameService gameService)
        {
            _gameService = gameService; 
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _gameService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpPost("add")]
        public IActionResult Add(Game game)
        {
            var result = _gameService.Add(game);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(Game game)
        {
            var result = _gameService.Delete(game);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(Game game)
        {
            var result = _gameService.Update(game);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("getbyid")]
        public IActionResult GetById(int gameId)
        {
            var result = _gameService.GetById(gameId);
            if (result.Success)
            { 
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
