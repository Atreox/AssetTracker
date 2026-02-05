using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetTracker.Application.DTO.Users;

namespace AssetTracker.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllAsync();
        Task<UserDto?> GetByIdAsync(int id);
        Task<int> CreateAsync(UserCreateDto dto);
        Task UpdateAsync(int id, UserUpdateDto dto);
        Task DeleteAsync(int id);
    }
}
