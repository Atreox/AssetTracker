using AssetTracker.Application.DTO.Departments;
using AssetTracker.Application.Interfaces.Repositories;
using AssetTracker.Application.Interfaces.Services;
using AssetTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracker.Application.Services
{
    public class DepartmentService:IDepartmentService
    {

        private readonly IDepartmentRepositories _departmentRepository;

        public DepartmentService(IDepartmentRepositories repo)
        {
            _departmentRepository = repo;
        }

        public async Task<List<DepartmentDto>> GetAllAsync()
        {
            var list = await _departmentRepository.GetAllAsync();

            return list.Select(x => new DepartmentDto
            {
                Id=x.Id,
                DeptName=x.DeptName,
                Location=x.Location
            }).ToList();
        }


        public async Task<DepartmentDto?> GetByIdAsync(int id)
        {
            var x = await _departmentRepository.GetByIdAsync(id);
            if (x == null) return null;

            return new DepartmentDto
            {
                DeptName = x.DeptName,
                Location = x.Location
            };
        }


        public async Task<int> CreateAsync(DepartmentCreateDto dto)
        {
            var entity = new Department
            {
                DeptName=dto.DeptName,
                Location=dto.Location
            };

            await _departmentRepository.AddAsync(entity);
            await _departmentRepository.SaveChangesAsync();

            return entity.Id;
        }


        public async Task UpdateAsync(int id, DepartmentUpdateDto dto)
        {
            var entity = await _departmentRepository.GetByIdAsync(id);
            if (entity == null) throw new Exception("Department not found");

            entity.DeptName = dto.DeptName;
            entity.Location = dto.Location;

            _departmentRepository.Update(entity);
            await _departmentRepository.SaveChangesAsync();
        }



        public async Task DeleteAsync(int id)
        {
            var entity = await _departmentRepository.GetByIdAsync(id);
            if (entity == null) throw new Exception("Department not found");

            _departmentRepository.Delete(entity);
            await _departmentRepository.SaveChangesAsync();
        }
    }
}
