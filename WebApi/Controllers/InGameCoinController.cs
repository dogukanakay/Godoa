using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InGameCoinController : ControllerBase
    {
        IInGameCoinService _inGameCoinService;
        public InGameCoinController(IInGameCoinService inGameCoinService)
        {
            _inGameCoinService = inGameCoinService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _inGameCoinService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("add")]
        public IActionResult Add(InGameCoin inGameCoin)
        {
            var result = _inGameCoinService.Add(inGameCoin);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(InGameCoin inGameCoin)
        {
            var result = _inGameCoinService.Delete(inGameCoin);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(InGameCoin inGameCoin)
        {
            var result = _inGameCoinService.Update(inGameCoin);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int inGameCoinId)
        {
            var result = _inGameCoinService.GetById(inGameCoinId);
            if (result.Success)
            { 
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
