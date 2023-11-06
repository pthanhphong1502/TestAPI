using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Interface;
using WebAPI.Models.Dtos;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatelogyController : ControllerBase
    {
        private readonly ICatelogy _cateRepository;

        public CatelogyController(ICatelogy cateRepository)
        {
            _cateRepository = cateRepository;
        }

        [AllowAnonymous]
        [HttpGet("GetAllCatelogies")]
        public async Task<ActionResult> GetAllCatelogies()
        {
            try
            {
                return Ok(await _cateRepository.GetAllCatelogyAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [AllowAnonymous]
        [HttpGet("GetBy{id}")]
        public async Task<ActionResult> GetCatelogyById(int id)
        {
            var posts = await _cateRepository.GetCatelogyAsync(id);
            return posts == null ? NotFound() : Ok(posts);

        }
        [HttpPost("AddCatelogy")]
        public async Task<ActionResult> AddNewCatelogy(CatelogyDto model)
        {
            var newPost = await _cateRepository.AddCatelogyAsync(model);
            var posts = await _cateRepository.GetCatelogyAsync(newPost);
            return posts == null ? NotFound() : Ok(posts);
        }
        [HttpPut("UpdateCatelogy{id}")]
        public async Task<IActionResult> UpdateCatelogy(int id, CatelogyDto model)
        {
            if (id != model.CatelogyId)
            {
                return NotFound();
            }
            await _cateRepository.UpdateCatelogyAsync(id, model);
            return Ok();
        }
        [HttpDelete("DeleteBy{id}")]
        public async Task<IActionResult> DeleteCatelogy(int id)
        {
            var post = await _cateRepository.GetCatelogyAsync(id);

            if (post == null)
            {
                return NotFound();
            }
            await _cateRepository.DeleteCatelogyAsync(id);
            return Ok();
        }
    }
}
