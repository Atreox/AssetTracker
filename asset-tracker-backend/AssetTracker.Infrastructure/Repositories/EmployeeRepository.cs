using AssetTracker.Application.Interfaces.Repositories;
using AssetTracker.Domain.Entities;
using AssetTracker.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AssetTracker.Infrastructure.Repositories
{
    public class EmployeeRepository:IEmployeeRepositories
    {
        private readonly AppDbContext _ctx;


        public EmployeeRepository(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public Task<List<Employee>> GetAllAsync()
        => _ctx.Employees.ToListAsync();

        public Task<Employee?> GetByIdAsync(int id)
            => _ctx.Employees.FirstOrDefaultAsync(x => x.Id == id);

        public async Task AddAsync(Employee employee)
            => await _ctx.Employees.AddAsync(employee);

        public void Update(Employee employee)
            => _ctx.Employees.Update(employee);

        public void Delete(Employee employee)
            => _ctx.Employees.Remove(employee);

        public Task SaveChangesAsync()
            => _ctx.SaveChangesAsync();

    }
}
