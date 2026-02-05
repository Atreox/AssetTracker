using AssetTracker.Application.DTO.Employees;
using AssetTracker.Application.DTO.Users;
using AssetTracker.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
namespace AssetTracker.Api.Controllers
{
   
        [ApiController]
        [Route("api/[Controller]")]
        public class EmployeeController : ControllerBase
        {

            private readonly IEmployeeService _employeeService;


            public EmployeeController(IEmployeeService employeeService)
            {
            _employeeService = employeeService;
            }

            [HttpGet]
            public Task<List<EmployeeDto>> GetAll()
            => _employeeService.GetAllAsync();

            [HttpGet("{id}")]
            public async Task<IActionResult> Get(int id)
            {
                var x = await _employeeService.GetByIdAsync(id);
                if (x == null) return NotFound();
                return Ok(x);
            }

            [HttpPost]
            public async Task<IActionResult> Create([FromBody]EmployeeCreateDto dto)
            {
            Console.WriteLine($"Received DTO:");
            Console.WriteLine($"FullName: {dto?.FullName ?? "NULL"}");
            Console.WriteLine($"Email: {dto?.Email ?? "NULL"}");
            Console.WriteLine($"DepartmentId: {dto?.DepartmentId}");
            var id = await _employeeService.CreateAsync(dto);
            Console.WriteLine(id);
                return CreatedAtAction(nameof(Get), new { id }, null);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> Update(int id, EmployeeUpdateDto dto)
            {
                await _employeeService.UpdateAsync(id, dto);
                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id)
            {
                await _employeeService.DeleteAsync(id);
                return NoContent();
            }

        }
    
}