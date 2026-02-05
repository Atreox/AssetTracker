using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetTracker.Application.DTO.Auth;

namespace AssetTracker.Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task RegisterAsync(RegisterRequest req);
        Task<bool> VerifyLoginAsync(LoginRequest req);
        Task ChangePasswordAsync(int userId, ChangePasswordRequest req);
    }
}
