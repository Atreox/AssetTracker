using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetTracker.Domain.Entities;

namespace AssetTracker.Application.Interfaces.Repositories
{
    public interface IUserRepositories
    {
        Task<List<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task AddAsync(User user);
        Task DeleteAsync(User user);
        Task<User?> GetByUsernameAsync(string username);

        Task UpdateAsync(User user);
        Task SaveChangesAsync();

    }
}
