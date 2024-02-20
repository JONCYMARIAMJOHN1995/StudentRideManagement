using Microsoft.AspNetCore.Identity;
using StudentRideManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRideManagement.Repositories
{
    public interface IAdministrationRepository
    {
        Task<IdentityResult> CreateRole(CreateRole user);
        IEnumerable<IdentityRole> GetRoles();
    }
}
