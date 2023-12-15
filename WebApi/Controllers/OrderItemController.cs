using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        IOrderItemService _orderItemService;
        public OrderItemController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        [HttpGet("getall")]

        public async Task<IActionResult> GetAll()
        {
            var result = await _orderItemService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpPost("add")]
        public IActionResult Add(OrderItem orderItem)
        {
            var result = _orderItemService.Add(orderItem);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(OrderItem orderItem)
        {
            var result = _orderItemService.Delete(orderItem);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(OrderItem orderItem)
        {
            var result = _orderItemService.Update(orderItem);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int orderItemId)
        {
            var result = await _orderItemService.GetById(orderItemId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getorderitemsdetailbyorderid")]
        public async Task<IActionResult> GetOrderItemsDetailByOrderId(int orderId)
        {
            var result = await _orderItemService.GetOrderItemDetailsOfOrderByOrderId(orderId);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

    }
}
