using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameCategoryController : ControllerBase
    {
        IGameCategoryService _gameCategoryService;

        public GameCategoryController(IGameCategoryService gameCategoryService)
        {
            _gameCategoryService = gameCategoryService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _gameCategoryService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }


        [HttpPost("add")]
        public IActionResult Add(GameCategory gameCategory)
        {
            var result = _gameCategoryService.Add(gameCategory);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(GameCategory gameCategory)
        {
            var result = _gameCategoryService.Delete(gameCategory);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(GameCategory gameCategory)
        {
            var result = _gameCategoryService.Update(gameCategory);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int gameCategoryId)
        {
            var result = await _gameCategoryService.GetById(gameCategoryId);
            if (result.Success)
            {
                return Ok(result); 
            }
            return BadRequest(result);
        }
    }
}
