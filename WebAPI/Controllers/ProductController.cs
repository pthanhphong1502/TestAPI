using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebAPI.Interface;
using WebAPI.Models;
using WebAPI.Models.Dtos;
using WebAPI.Repository;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProduct _productRepository;

        public ProductController(IProduct productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("GetAllProducts")]
        public async Task<ActionResult> GetAllProducts()
        {
            try
            {
                return Ok(await _productRepository.GetAllProductAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [AllowAnonymous]
        [HttpGet("GetBy{id}")]
        public async Task<ActionResult> GetProductById(int id)
        {
            var posts = await _productRepository.GetProductAsync(id);
            return posts == null ? NotFound() : Ok(posts);

        }
        [HttpPost("AddProduct")]
        public async Task<ActionResult> AddNewProduct(ProductDto model)
        {
            var newPost = await _productRepository.AddProductAsync(model);
            var posts = await _productRepository.GetProductAsync(newPost);
            return posts == null ? NotFound() : Ok(posts);
        }
        [HttpPut("UpdateProduct{id}")]
        public async Task<IActionResult> UpdateProduct(int id, ProductDto model)
        {
            if (id != model.ProductId)
            {
                return NotFound();
            }
            await _productRepository.UpdateProductAsync(id, model);
            return Ok();
        }
        [HttpDelete("DeleteBy{id}")]
        public async Task<IActionResult> DeleteProductt(int id)
        {
            var post = await _productRepository.GetProductAsync(id);

            if (post == null)
            {
                return NotFound();
            }
            await _productRepository.DeleteProductAsync(id);
            return Ok();
        }

        [HttpGet("SearchProducts")]
        public async Task<IActionResult> SearchProducts([FromQuery] string productName)
        {
            var products = await _productRepository.GetAllProductAsync();

            if (!string.IsNullOrEmpty(productName))
            {
                products = products
                    .Where(p => p.ProductName != null && p.ProductName.Contains(productName))
                    .ToList();
            }

            return Ok(products);
        }

    }
}
