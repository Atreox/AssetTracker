using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetTracker.Application.Interfaces.Services;
using Microsoft.AspNetCore.Identity;


namespace AssetTracker.Infrastructure.Services
{
    public class PasswordHasherService : IPasswordHasherService
    {

        private readonly PasswordHasher<string> _hasher = new();

        public string Hash(string password)
            => _hasher.HashPassword(null!, password);

        public bool Verify(string password, string passwordHash)
            => _hasher.VerifyHashedPassword(null!, passwordHash, password)
               == PasswordVerificationResult.Success;


    }
}
