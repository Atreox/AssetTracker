
using AssetTracker.Application.DTO.Users;
using AssetTracker.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace AssetTracker.Api.Controllers
{

    [ApiController]
    [Route("api/[Controller]")]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;


        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public Task<List<UserDto>> GetAll()
        => _userService.GetAllAsync();

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var x = await _userService.GetByIdAsync(id);
            if (x == null) return NotFound();
            return Ok(x);
        }
        /*
        [HttpPost]
        public async Task<IActionResult> Create(UserCreateDto dto)
        {
            var id = await _userService.CreateAsync(dto);
            return CreatedAtAction(nameof(Get), new { id }, null);
        }
        */
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UserUpdateDto dto)
        {
            await _userService.UpdateAsync(id, dto);
            return NoContent();
        }

        /*
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.DeleteAsync(id);
            return NoContent();
        }
        */

    }
}
