using AssetTracker.Application.DTO.Employees;
using AssetTracker.Application.DTO.Users;
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
    public class EmployeeService:IEmployeeService
    {
        private readonly IEmployeeRepositories _employeeRepositories;

        public EmployeeService(IEmployeeRepositories repo)
        {
            _employeeRepositories = repo;
        }

        public async Task<List<EmployeeDto>> GetAllAsync()
        {
            var list = await _employeeRepositories.GetAllAsync();

            return list.Select(x => new EmployeeDto
            {
                Id = x.Id,
                FullName = x.FullName,
                Email = x.Email,
                DepartmentId = x.DepartmentId
            }).ToList();
        }
        public async Task<EmployeeDto?> GetByIdAsync(int id)
        {
            var x = await _employeeRepositories.GetByIdAsync(id);
            if (x == null) return null;

            return new EmployeeDto
            {
                Id = x.Id,
                FullName = x.FullName,
                Email = x.Email,
                DepartmentId = x.DepartmentId
            };
        }

        public async Task<int> CreateAsync(EmployeeCreateDto dto)
        {
            var entity = new Employee
            {
                FullName = dto.FullName,
                Email = dto.Email,
                DepartmentId = dto.DepartmentId
            };

            await _employeeRepositories.AddAsync(entity);
            await _employeeRepositories.SaveChangesAsync();

            return entity.Id;
        }

        public async Task UpdateAsync(int id, EmployeeUpdateDto dto)
        {
            var entity = await _employeeRepositories.GetByIdAsync(id);
            if (entity == null) throw new Exception("Employee not found");

            entity.FullName = dto.FullName;
            entity.Email = dto.Email;
            entity.DepartmentId = dto.DepartmentId;

            _employeeRepositories.Update(entity);
            await _employeeRepositories.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _employeeRepositories.GetByIdAsync(id);
            if (entity == null) throw new Exception("Employee not found");

            _employeeRepositories.Delete(entity);
            await _employeeRepositories.SaveChangesAsync();
        }

    }
}
