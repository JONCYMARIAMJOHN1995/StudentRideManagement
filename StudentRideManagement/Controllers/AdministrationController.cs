using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentRideManagement.Models;
using StudentRideManagement.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRideManagement.Controllers
{
    public class AdministrationController : ControllerBase
    {
        private readonly IAdministrationRepository _administrationRepository;

        public AdministrationController(IAdministrationRepository administrationRepository)
        {
            _administrationRepository = administrationRepository;
        }

        [HttpPost("CreateRole")]
        public async Task<IActionResult> CreateRole(CreateRole role)
        {
            var result = await _administrationRepository.CreateRole(role);

            if (result.Succeeded)
            {
                return Ok("Role Created");
            }
            else
            {
                string errorMessage = "";
                foreach (IdentityError error in result.Errors)
                {
                    errorMessage = errorMessage + " " + error.Description;
                }
                throw new BadHttpRequestException(errorMessage);
            }
        }

        [HttpGet("GetRoles")]
        public IEnumerable<IdentityRole> GetRoles()
        {
            var result = _administrationRepository.GetRoles();
            if(result != null)
                return result;
            throw new BadHttpRequestException("Something went wrong");
        }
    }
}
