using AssetTracker.Application.DTO.Assets;
using AssetTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracker.Application.Interfaces.Repositories
{
    public interface IAssetRepositories
    {

        Task<List<Asset>> GetAllAsync();
        Task<Asset?> GetByIdAsync(int id);
        Task AddAsync(Asset asset);
        void Update(Asset asset);
        void Delete(Asset asset);
        Task<List<AssetListItemDto>> GetAssetListAsync();
        //Task AddAssignAsync(int id,Asset asset);
        Task SaveChangesAsync();
    }
}
