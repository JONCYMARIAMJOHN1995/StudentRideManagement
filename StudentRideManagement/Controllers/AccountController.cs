using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentRideManagement.DTO;
using StudentRideManagement.Models;
using StudentRideManagement.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRideManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public AccountController(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser(RegisterUserDTO userDto)
        {
            var result = await _accountRepository.RegisterUser(_mapper.Map<RegisterUser>(userDto));

            if (result.Succeeded)
            {
                return Ok("Created User");
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

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginUser user)
        {
            var result = await _accountRepository.Login(user);
            if (result)
            {
                var tokenString = _accountRepository.GenerateTokenString(user);
                return Ok(tokenString);
            }
                
            throw new BadHttpRequestException("Bad Request");

        }
    }
}
