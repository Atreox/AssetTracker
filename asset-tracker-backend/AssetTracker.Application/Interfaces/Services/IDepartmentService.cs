using AssetTracker.Application.DTO.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracker.Application.Interfaces.Services
{
    public interface IDepartmentService
    {
        Task<List<DepartmentDto>> GetAllAsync();
        Task<DepartmentDto?> GetByIdAsync(int id);
        Task<int> CreateAsync(DepartmentCreateDto dto);
        Task UpdateAsync(int id, DepartmentUpdateDto dto);
        Task DeleteAsync(int id);

    }
}
