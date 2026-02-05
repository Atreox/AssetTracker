using AssetTracker.Application.DTO.Assets;
using AssetTracker.Application.DTO.Users;
using AssetTracker.Application.Interfaces.Services;
using AssetTracker.Application.Services;
using AssetTracker.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AssetTracker.Api.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AssetController:ControllerBase
    {
        private readonly IAssetService _assetService;


        public AssetController(IAssetService assetService)
        {
            _assetService = assetService;
        }

        [HttpGet]
        public Task<List<AssetDto>> GetAll()
        => _assetService.GetAllAsync();

        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var x = await _assetService.GetByIdAsync(id);
            if (x == null) return NotFound();
            return Ok(x);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AssetCreateDto dto)
        {
            var id = await _assetService.CreateAsync(dto);
            return CreatedAtAction(nameof(Get), new { id }, null);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, AssetUpdateDto dto)
        {
            await _assetService.UpdateAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _assetService.DeleteAsync(id);
            return NoContent();
        }
        [HttpGet("List")]
        public async Task<IActionResult> List()
        => Ok(await _assetService.GetAssetListAsync());

        [HttpPatch("{id}/assign")]
        public async Task<IActionResult> Assign(int id, AssetAssignRequestDto dto)
        {
            await _assetService.AssignAsync(id, dto.EmployeeId);
            //return Ok(result);
            return NoContent();
        }

        [HttpPatch("{id}/unassign")]
        public async Task<IActionResult> Unassign(int id)
        {

            await _assetService.UnassignAsync(id);
            //return Ok(result);
            return NoContent();
        }

    }
}
