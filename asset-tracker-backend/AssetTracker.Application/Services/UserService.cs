using AssetTracker.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetTracker.Application.DTO.Users;
using AssetTracker.Application.Interfaces.Repositories;
using AssetTracker.Domain.Entities;

namespace AssetTracker.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepositories _userRepository;
        private readonly IPasswordHasherService _hasher;

        public UserService(IUserRepositories repo, IPasswordHasherService hasher)
        {
            _userRepository = repo;
            _hasher = hasher;
        }

        public async Task<List<UserDto>> GetAllAsync()
        {
            var list = await _userRepository.GetAllAsync();

            return list.Select(x => new UserDto
            {
                Id = x.Id,
                Username=x.Username
            }).ToList();
        }


        public async Task<UserDto?> GetByIdAsync(int id)
        {
            var x = await _userRepository.GetByIdAsync(id);
            if (x == null) return null;

            return new UserDto
            {Id = x.Id,
                Username = x.Username
            };
        }


        public async Task<int> CreateAsync(UserCreateDto dto)
        {
            var entity = new User
            {
                Username = dto.Username,
                //Password = dto.Password
            };

            await _userRepository.AddAsync(entity);
            await _userRepository.SaveChangesAsync();

            return entity.Id;
        }


        public async Task UpdateAsync(int id, UserUpdateDto dto)
        {
            var entity = await _userRepository.GetByIdAsync(id);
            if (entity == null) throw new Exception("User not found");

            entity.Username = dto.Username;
            //entity.Password = dto.Password;

            _userRepository.UpdateAsync(entity);
            await _userRepository.SaveChangesAsync();
        }
        


        public async Task DeleteAsync(int id)
        {
            var entity = await _userRepository.GetByIdAsync(id);
            if (entity == null) throw new Exception("User not found");

            _userRepository.DeleteAsync(entity);
            await _userRepository.SaveChangesAsync();
        }


    }
}
