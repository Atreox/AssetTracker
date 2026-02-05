using AssetTracker.Application.DTO.Auth;
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
    public class AuthService : IAuthService
    {
        private readonly IUserRepositories _authRepo;
        private readonly IPasswordHasherService _hasher;

        public AuthService(IUserRepositories autRepo, IPasswordHasherService hasher)
        {
            _authRepo = autRepo;
            _hasher = hasher;
        }

        public async Task RegisterAsync(RegisterRequest req)
        {
            var existing = await _authRepo.GetByUsernameAsync(req.Username);
            if (existing is not null)
                throw new Exception("Username already exists");

            var user = new User
            {
                Username = req.Username,
                Password = _hasher.Hash(req.Password) 
            };

            await _authRepo.AddAsync(user);
        }

        public async Task<bool> VerifyLoginAsync(LoginRequest req)
        {
            var user = await _authRepo.GetByUsernameAsync(req.Username);
            if (user is null) return false;

            return _hasher.Verify(req.Password, user.Password);
        }

        public async Task ChangePasswordAsync(int userId, ChangePasswordRequest req)
        {
            var user = await _authRepo.GetByIdAsync(userId)
                       ?? throw new Exception("User not found");

            user.Password = _hasher.Hash(req.NewPassword);
            await _authRepo.UpdateAsync(user);
        }
    }

}
