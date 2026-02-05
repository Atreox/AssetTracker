using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetTracker.Domain.Entities;

namespace AssetTracker.Application.Interfaces.Repositories
{
    public interface IDepartmentRepositories
    {

        Task<List<Department>> GetAllAsync();
        Task<Department?> GetByIdAsync(int id);
        Task AddAsync(Department department);
        void Update(Department department);
        void Delete(Department department);
        Task SaveChangesAsync();
    }
}
