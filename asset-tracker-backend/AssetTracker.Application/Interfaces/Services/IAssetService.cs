using AssetTracker.Application.DTO.Assets;
using AssetTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracker.Application.Interfaces.Services
{
    public interface IAssetService
    {
        Task<List<AssetDto>> GetAllAsync();
        Task<AssetDto?> GetByIdAsync(int id);
        Task<int> CreateAsync(AssetCreateDto dto);
        Task UpdateAsync(int id, AssetUpdateDto dto);
        Task DeleteAsync(int id);
        Task<List<AssetListItemDto>> GetAssetListAsync();
        Task AssignAsync(int assetId, int employeeId);
        Task UnassignAsync(int assetId);

    }
}
