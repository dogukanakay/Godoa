using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkinController : ControllerBase
    {
        ISkinService _skinService;
        public SkinController(ISkinService skinService)
        {
            _skinService = skinService;
        }

        [HttpGet("getall")]

        public IActionResult GetAll()
        {
            var result = _skinService.GetAll();

            if(result.Success) 
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]

        public IActionResult Add(Skin skin)
        {
            var result = _skinService.Add(skin);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("update")]

        public IActionResult Update(Skin skin)
        {
            var result = _skinService.Update(skin);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getall")]

        public IActionResult Delete(Skin skin)
        {
            var result = _skinService.Delete(skin);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]

        public IActionResult GetById(int skinId)
        {
            var result = _skinService.GetById(skinId);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
