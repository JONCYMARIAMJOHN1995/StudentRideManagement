using Microsoft.AspNetCore.Identity;
using StudentRideManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRideManagement.Repositories
{
    public class AdministrationRepository : IAdministrationRepository
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public AdministrationRepository(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        public async Task<IdentityResult> CreateRole(CreateRole role)
        {
            IdentityRole identityRole = new IdentityRole
            {
                Name = role.RoleName
            };
            IdentityResult result = await roleManager.CreateAsync(identityRole);
            return result;
        }

        public IEnumerable<IdentityRole> GetRoles()
        {
            var roles = roleManager.Roles;
            return roles;
        }
    }
}
