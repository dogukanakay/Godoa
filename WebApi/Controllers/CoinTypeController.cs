using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoinTypeController : ControllerBase
    {
        ICoinTypeService _coinTypeService;
        public CoinTypeController(ICoinTypeService coinTypeService)
        {
            _coinTypeService=coinTypeService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _coinTypeService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }


        [HttpPost("add")]
        public IActionResult Add(CoinType coinType)
        {
            var result = _coinTypeService.Add(coinType);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(CoinType coinType)
        {
            var result = _coinTypeService.Delete(coinType);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(CoinType coinType)
        {
            var result = _coinTypeService.Update(coinType);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("getbyid")]
        public IActionResult GetById(int coinTypeId)
        {
            var result = _coinTypeService.GetById(coinTypeId);
            if (result.Success)
            { 
                return Ok(result); 
            }
            return BadRequest(result);
        }
1    }
}
