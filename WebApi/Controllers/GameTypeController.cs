using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameTypeController : ControllerBase
    {
        IGameTypeService _gameTypeService;
        public GameTypeController(IGameTypeService gameTypeService)
        {
            _gameTypeService = gameTypeService;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _gameTypeService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpPost("add")]
        public IActionResult Add(GameType gameType)
        {
            var result = _gameTypeService.Add(gameType);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(GameType gameType)
        {
            var result = _gameTypeService.Delete(gameType);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(GameType gameType)
        {
            var result = _gameTypeService.Update(gameType);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int gameTypeId)
        {
            var result = await _gameTypeService.GetById(gameTypeId);
            if (result.Success)
            { 
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
