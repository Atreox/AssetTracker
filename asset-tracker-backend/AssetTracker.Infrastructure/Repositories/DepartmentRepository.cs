using AssetTracker.Application.Interfaces.Repositories;
using AssetTracker.Domain.Entities;
using AssetTracker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracker.Infrastructure.Repositories
{
    public class DepartmentRepository:IDepartmentRepositories
    {
        private readonly AppDbContext _ctx;


        public DepartmentRepository(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public Task<List<Department>> GetAllAsync()
        => _ctx.Departments.ToListAsync();

        public Task<Department?> GetByIdAsync(int id)
            => _ctx.Departments.FirstOrDefaultAsync(x => x.Id == id);

        public async Task AddAsync(Department department)
            => await _ctx.Departments.AddAsync(department);

        public void Update(Department department)
            => _ctx.Departments.Update(department);

        public void Delete(Department department)
            => _ctx.Departments.Remove(department);

        public Task SaveChangesAsync()
            => _ctx.SaveChangesAsync();


    }
}
