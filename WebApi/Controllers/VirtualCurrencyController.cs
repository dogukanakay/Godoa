using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VirtualCurrencyController : ControllerBase
    {
        IVirtualCurrencyService _virtualCurrencyService;
        public VirtualCurrencyController(IVirtualCurrencyService virtualCurrencyService)
        {
            _virtualCurrencyService = virtualCurrencyService;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _virtualCurrencyService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("add")]
        public IActionResult Add(VirtualCurrency virtualCurrency)
        {
            virtualCurrency.IsUsed = false;
            var result = _virtualCurrencyService.Add(virtualCurrency);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(VirtualCurrency virtualCurrency)
        {
            var result = _virtualCurrencyService.Delete(virtualCurrency);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(VirtualCurrency virtualCurrency)
        {
            var result = _virtualCurrencyService.Update(virtualCurrency);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int virtualCurrencyId)
        {
            var result = await _virtualCurrencyService.GetById(virtualCurrencyId);
            if (result.Success)
            { 
                return Ok(result);
            }
            return BadRequest(result);
        }
        
    }
}
