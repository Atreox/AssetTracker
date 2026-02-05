using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracker.Application.DTO.Auth
{
    public record ChangePasswordRequest(
    string NewPassword
);
}
