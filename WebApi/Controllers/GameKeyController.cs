using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameKeyController : ControllerBase
    {
        IGameKeyService _gameKeyService;
        public GameKeyController(IGameKeyService gameKeyService)
        {
            _gameKeyService = gameKeyService;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _gameKeyService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpPost("add")]
        public IActionResult Add(GameKey gameKey)
        {
            gameKey.IsUsed = false;
            var result = _gameKeyService.Add(gameKey);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(GameKey gameKey)
        {
            var result = _gameKeyService.Delete(gameKey);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(GameKey gameKey)
        {
            var result = _gameKeyService.Update(gameKey);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int gameKeyId)
        {
            var result = await _gameKeyService.GetById(gameKeyId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getalldetails")]
        public async Task<IActionResult> GetAllDetails()
        {
            var result = await _gameKeyService.GetGameKeyDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
