using AssetTracker.Application.DTO.Assets;
using AssetTracker.Application.Interfaces.Repositories;
using AssetTracker.Domain.Entities;
using AssetTracker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracker.Infrastructure.Repositories
{
    public class AssetRepository:IAssetRepositories
    {
        private readonly AppDbContext _ctx;


        public AssetRepository(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public Task<List<Asset>> GetAllAsync()
        => _ctx.Assets.ToListAsync();

        public Task<Asset?> GetByIdAsync(int id)
            => _ctx.Assets.FirstOrDefaultAsync(x => x.Id == id);

        public async Task AddAsync(Asset asset)
            => await _ctx.Assets.AddAsync(asset);

        public void Update(Asset asset)
            => _ctx.Assets.Update(asset);

        public void Delete(Asset asset)
            => _ctx.Assets.Remove(asset);

        public Task SaveChangesAsync()
            => _ctx.SaveChangesAsync();

        public Task<List<AssetListItemDto>> GetAssetListAsync()
        {
            return _ctx.Assets
                .AsNoTracking()
                .Select(a => new AssetListItemDto(
                    a.Id,
                    a.AssetName,
                    a.SerialNumber,
                    a.AssetType,
                    a.PurchaseDate,
                    a.EmployeeId,
                    a.Employee != null ? a.Employee.FullName : null,
                    a.Employee != null ? a.Employee.DepartmentId : null,
                    a.Employee != null ? a.Employee.Deparment.DeptName : null
                ))
                .ToListAsync();
        }
    }
}
