using Microsoft.AspNetCore.Identity;
using StudentRideManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRideManagement.Repositories
{
    public interface IAccountRepository
    {
        Task<IdentityResult> RegisterUser(RegisterUser user);
        Task<bool> Login(LoginUser user);
        string GenerateTokenString(LoginUser user);
        IdentityRole GetRoleData(Guid roleId);
    }
}
