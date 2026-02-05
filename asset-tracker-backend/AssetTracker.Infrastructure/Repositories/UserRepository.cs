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
    public class UserRepository:IUserRepositories
    {
        private readonly AppDbContext _ctx;


        public UserRepository(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public Task<List<User>> GetAllAsync()
        => _ctx.Users.ToListAsync();

        public Task<User?> GetByIdAsync(int id)
            => _ctx.Users.FirstOrDefaultAsync(x => x.Id == id);

        public async Task AddAsync(User user) {
            _ctx.Users.AddAsync(user);
            await _ctx.SaveChangesAsync();
        }
        public async Task UpdateAsync(User user)
        {
           _ctx.Users.Update(user);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteAsync(User user)
        {
            _ctx.Users.Remove(user);
            await _ctx.SaveChangesAsync();
        }

        public Task SaveChangesAsync()
            => _ctx.SaveChangesAsync();

        public Task<User?> GetByUsernameAsync(string username)
    => _ctx.Users.FirstOrDefaultAsync(x => x.Username == username);

    }
}
