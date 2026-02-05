using AssetTracker.Application.DTO.Departments;
using AssetTracker.Application.DTO.Users;
using AssetTracker.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
namespace AssetTracker.Api.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class DepartmentController : ControllerBase
    {

        private readonly IDepartmentService _departmentService;


        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public Task<List<DepartmentDto>> GetAll()
        => _departmentService.GetAllAsync();

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var x = await _departmentService.GetByIdAsync(id);
            if (x == null) return NotFound();
            return Ok(x);
        }

        [HttpPost]
        public async Task<IActionResult> Create(DepartmentCreateDto dto)
        {
            var id = await _departmentService.CreateAsync(dto);
            return CreatedAtAction(nameof(Get), new { id }, null);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, DepartmentUpdateDto dto)
        {
            await _departmentService.UpdateAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _departmentService.DeleteAsync(id);
            return NoContent();
        }


    }
}
