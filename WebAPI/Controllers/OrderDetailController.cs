using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Interface;
using WebAPI.Models.Dtos;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetail _productRepository;

        public OrderDetailController(IOrderDetail productRepository)
        {
            _productRepository = productRepository;
        }

        [AllowAnonymous]
        [HttpGet("GetAllOrderDetails")]
        public async Task<ActionResult> GetAllOrderDetails()
        {
            try
            {
                return Ok(await _productRepository.GetAllOrderDetailAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [AllowAnonymous]
        [HttpGet("GetBy{id}")]
        public async Task<ActionResult> GetOrderDetailById(int id)
        {
            var posts = await _productRepository.GetOrderDetailAsync(id);
            return posts == null ? NotFound() : Ok(posts);

        }
        [HttpPost("AddOrderDetail")]
        public async Task<ActionResult> AddNewOrderDetail(OrderDetailDto model)
        {
            var newPost = await _productRepository.AddOrderDetailAsync(model);
            var posts = await _productRepository.GetOrderDetailAsync(newPost);
            return posts == null ? NotFound() : Ok(posts);
        }
        [HttpPut("UpdateOrder{id}")]
        public async Task<IActionResult> UpdateOrderDetail(int id, OrderDetailDto model)
        {
            if (id != model.OrderId)
            {
                return NotFound();
            }
            await _productRepository.UpdateOrderDetailAsync(id, model);
            return Ok();
        }
        [HttpDelete("DeleteBy{id}")]
        public async Task<IActionResult> DeleteOrderDetail(int id)
        {
            var post = await _productRepository.GetOrderDetailAsync(id);

            if (post == null)
            {
                return NotFound();
            }
            await _productRepository.DeleteOrderDetailAsync(id);
            return Ok();
        }
    }
}
