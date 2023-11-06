using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Interface;
using WebAPI.Models;
using WebAPI.Models.Dtos;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUser _userRepository;
        private readonly UserManager<Member> userManager;
        public UsersController(IUser userRepository, UserManager<Member> userManager)
        {
            _userRepository = userRepository;
            this.userManager = userManager;
        }

        [AllowAnonymous]
        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                return Ok(await _userRepository.GetAllUserAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [AllowAnonymous]
        [HttpGet("GetUserBy/{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPut("UpdateUser/{id}")]
        public async Task<IActionResult> UpdateUser(string id, GetAllUserDto model)
        {
            var user = await userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound("User not found.");
            }

            user.CompanyName = model.CompanyName;
            user.City = model.City;
            user.Country = model.Country;

            var result = await userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return Ok("User updated successfully.");
            }
            else
            {
                // Handle validation errors or other errors here
                return BadRequest(result.Errors);
            }
        }
    }
}
