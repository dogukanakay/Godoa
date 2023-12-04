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

        public async Task<IActionResult> GetAll()
        {
            var result = await _skinService.GetAll();

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


        [HttpPost("update")]

        public IActionResult Update(Skin skin)
        {
            var result = _skinService.Update(skin);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("delete")]

        public IActionResult Delete(Skin skin)
        {
            var result = _skinService.Delete(skin);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]

        public async Task<IActionResult> GetById(int skinId)
        {
            var result = await _skinService.GetById(skinId);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getalldetails")]
        public async Task<IActionResult> GetallDetails()
        {
            var result = await _skinService.GetSkinDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
