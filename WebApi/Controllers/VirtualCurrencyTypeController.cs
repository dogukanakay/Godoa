using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VirtualCurrencyTypeController : ControllerBase
    {
        IVirtualCurrencyTypeService _virtualCurrencyTypeService;
        public VirtualCurrencyTypeController(IVirtualCurrencyTypeService virtualCurrencyTypeService)
        {
            _virtualCurrencyTypeService=virtualCurrencyTypeService;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _virtualCurrencyTypeService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }


        [HttpPost("add")]
        public IActionResult Add(VirtualCurrencyType virtualCurrencyType)
        {
            var result = _virtualCurrencyTypeService.Add(virtualCurrencyType);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(VirtualCurrencyType virtualCurrencyType)
        {
            var result = _virtualCurrencyTypeService.Delete(virtualCurrencyType);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(VirtualCurrencyType virtualCurrencyType)
        {
            var result = _virtualCurrencyTypeService.Update(virtualCurrencyType);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int virtualCurrencyTypeId)
        {
            var result = await _virtualCurrencyTypeService.GetById(virtualCurrencyTypeId);
            if (result.Success)
            { 
                return Ok(result); 
            }
            return BadRequest(result);
        }
       
       
    }
}
