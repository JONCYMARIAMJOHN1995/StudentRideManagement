
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using StudentRideManagement.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace StudentRideManagement.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration config;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountRepository(UserManager<ApplicationUser> userManager, IConfiguration config,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            this.config = config;
            _roleManager = roleManager;
        }


        public async Task<IdentityResult> RegisterUser(RegisterUser user)
        {
            var identityUser = new ApplicationUser
            {
                UserName = user.Username,
                Email = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                RoleId = user.RoleId,
                CreatedDate = DateTime.Now
            };
            var result = await _userManager.CreateAsync(identityUser, user.Password);

            IdentityRole role = GetRoleData(user.RoleId);
            var roleName = role?.Name;


            await _userManager.AddToRoleAsync(identityUser, roleName);
            return result;
        }


        public async Task<bool> Login(LoginUser user)
        {
            var identityUser = await _userManager.FindByEmailAsync(user.Username);
            if (identityUser == null)
                return false;
            return await _userManager.CheckPasswordAsync(identityUser, user.Password);
        }


        public string GenerateTokenString(LoginUser user)
        {
            var identityUser = _userManager.FindByEmailAsync(user.Username);
            Guid roleId = identityUser.Result.RoleId;
            IdentityRole role = GetRoleData(roleId);
            string roleName = role?.Name;

            IEnumerable<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.Email, user.Username),
                new Claim(ClaimTypes.Role, roleName)
            };

            SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.GetSection("Jwt:Key").Value));

            SigningCredentials signingCred = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);

            


            var securityToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                issuer: config.GetSection("Jwt:Issuer").Value,
                audience: config.GetSection("Jwt:Audience").Value,
                signingCredentials: signingCred
            );

            string tokenString = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return tokenString;
        }

        public IdentityRole GetRoleData(Guid roleId)
        {
            IEnumerable<IdentityRole> roles = _roleManager.Roles;
            IdentityRole role = roles.FirstOrDefault(x => (x.Id.ToString()).Equals(roleId.ToString()));
            return role;
        }
    }
}
