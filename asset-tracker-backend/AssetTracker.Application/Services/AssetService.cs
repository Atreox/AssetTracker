using AssetTracker.Application.DTO.Assets;
using AssetTracker.Application.Interfaces.Services;
using AssetTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetTracker.Application.Interfaces.Repositories;

namespace AssetTracker.Application.Services
{
    public class AssetService : IAssetService
    {
        private readonly IAssetRepositories _assetRepository;

        public AssetService(IAssetRepositories repo)
        {
            _assetRepository = repo;
        }

        public async Task<List<AssetDto>> GetAllAsync()
        {
            var list = await _assetRepository.GetAllAsync();

            return list.Select(x => new AssetDto
            {
                Id = x.Id,
                AssetName = x.AssetName,
                AssetType = x.AssetType,
                SerialNumber = x.SerialNumber,
                PurchaseDate = x.PurchaseDate
            }).ToList();
        }


        public async Task<AssetDto?> GetByIdAsync(int id)
        {
            var x = await _assetRepository.GetByIdAsync(id);
            if (x == null) return null;

            return new AssetDto
            {
                Id = x.Id,
                AssetName = x.AssetName,
                AssetType = x.AssetType,
                SerialNumber = x.SerialNumber,
                PurchaseDate = x.PurchaseDate
            };
        }


        public async Task<int> CreateAsync(AssetCreateDto dto)
        {
            var entity = new Asset
            {
                AssetName = dto.AssetName,
                AssetType = dto.AssetType,
                SerialNumber = dto.SerialNumber,
                PurchaseDate = dto.PurchaseDate
            };

            await _assetRepository.AddAsync(entity);
            await _assetRepository.SaveChangesAsync();

            return entity.Id;
        }


        public async Task UpdateAsync(int id, AssetUpdateDto dto)
        {
            var entity = await _assetRepository.GetByIdAsync(id);
            if (entity == null) throw new Exception("Asset not found");

            entity.AssetName = dto.AssetName;
            entity.AssetType = dto.AssetType;
            entity.SerialNumber = dto.SerialNumber;
            entity.PurchaseDate = dto.PurchaseDate;

            _assetRepository.Update(entity);
            await _assetRepository.SaveChangesAsync();
        }



        public async Task DeleteAsync(int id)
        {
            var entity = await _assetRepository.GetByIdAsync(id);
            if (entity == null) throw new Exception("Asset not found");

            _assetRepository.Delete(entity);
            await _assetRepository.SaveChangesAsync();
        }

        public Task<List<AssetListItemDto>> GetAssetListAsync()
       => _assetRepository.GetAssetListAsync();


        public async Task AddAssignAsync(int id, AssetUpdateDto dto)
        {
            var entity = await _assetRepository.GetByIdAsync(id);
            if (entity == null) throw new Exception("Asset not found");

            entity.AssetName = dto.AssetName;
            entity.AssetType = dto.AssetType;
            entity.SerialNumber = dto.SerialNumber;
            entity.PurchaseDate = dto.PurchaseDate;

            _assetRepository.Update(entity);
            await _assetRepository.SaveChangesAsync();
        }


        public async Task AssignAsync(int assetId, int employeeId)
        {
            var asset = await _assetRepository.GetByIdAsync(assetId);
            if (asset is null)
                throw new Exception("Asset bulunamadı");

            if (asset.EmployeeId != null)
                throw new Exception("Asset zaten zimmetli");

            asset.EmployeeId = employeeId;

            await _assetRepository.SaveChangesAsync();
        }

        public async Task UnassignAsync(int assetId)
        {
            var asset = await _assetRepository.GetByIdAsync(assetId);
            if (asset is null)
                throw new Exception("Asset bulunamadı");

            if (asset.EmployeeId == null)
                throw new Exception("Asset zaten boşta");

            asset.EmployeeId = null;

            await _assetRepository.SaveChangesAsync();
        }





        /*
        public async Task AssignAsync(int assetId, int employeeId)
        {
            await _assetRepository.AssignAsync(assetId, employeeId);
            await _assetRepository.SaveChangesAsync();
        }

        public async Task UnassignAsync(int assetId)
        {
            await _assetRepository.UnassignAsync(assetId);
            await _assetRepository.SaveChangesAsync();
        }
        */


    }
}