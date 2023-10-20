using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController : ControllerBase
    {
        ISellerService _sellerService;
        public SellerController(ISellerService sellerService)
        {
            _sellerService = sellerService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _sellerService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("add")]
        public IActionResult Add(Seller seller)
        {
            var result = _sellerService.Add(seller);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(Seller seller)
        {
            var result = _sellerService.Delete(seller);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(Seller seller)
        {
            var result = _sellerService.Update(seller);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int sellerId)
        {
            var result = _sellerService.GetById(sellerId);
            if (result.Success)
            {
                return Ok(result); 
            }
            return BadRequest(result);
        }

    }
}
