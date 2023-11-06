using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Interface;
using WebAPI.Models.Dtos;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrder _productRepository;

        public OrderController(IOrder productRepository)
        {
            _productRepository = productRepository;
        }

        [AllowAnonymous]
        [HttpGet("GetAllOrders")]
        public async Task<ActionResult> GetAllOrders()
        {
            try
            {
                return Ok(await _productRepository.GetAllOrderAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [AllowAnonymous]
        [HttpGet("GetBy{id}")]
        public async Task<ActionResult> GetOrderById(int id)
        {
            var posts = await _productRepository.GetOrderAsync(id);
            return posts == null ? NotFound() : Ok(posts);

        }
        [HttpPost("AddOrder")]
        public async Task<ActionResult> AddNewOrder(OrderDto model)
        {
            var newPost = await _productRepository.AddOrderAsync(model);
            var posts = await _productRepository.GetOrderAsync(newPost);
            return posts == null ? NotFound() : Ok(posts);
        }
        [HttpPut("UpdateOrder{id}")]
        public async Task<IActionResult> UpdateOrder(int id, OrderDto model)
        {
            if (id != model.OrderId)
            {
                return NotFound();
            }
            await _productRepository.UpdateOrderAsync(id, model);
            return Ok();
        }
        [HttpDelete("DeleteBy{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var post = await _productRepository.GetOrderAsync(id);

            if (post == null)
            {
                return NotFound();
            }
            await _productRepository.DeleteOrderAsync(id);
            return Ok();
        }
    }
}
