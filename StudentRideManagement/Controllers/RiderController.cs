using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentRideManagement.CustomMiddlewares;
using StudentRideManagement.DTO;
using StudentRideManagement.Models;
using StudentRideManagement.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace StudentRideManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RiderController : ControllerBase
    {
        private readonly IRiderRepository _riderRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RiderController(IRiderRepository riderRepository, IMapper mapper, UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _riderRepository = riderRepository;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: api/Rider
        
        [HttpGet("GetAllRiders")]
        public IActionResult GetAllRiders()
        {
            
            var riders = _riderRepository.GetAllRiders();
            if (riders != null)
                return Ok(riders);
            else
                throw new Exception("Something went wrong");
            

        }
 

        // GET: api/Rider/id
        [HttpGet("{id}")]
        public IActionResult GetRider(int id)
        {
            var rider = _riderRepository.GetRider(id);
            if (rider != null)
                return Ok(rider);
            else
                throw new NotFoundException("Not found Rider with this Id");
        }

        //POST: api/Products/
        [Authorize(Roles = "Admin")]
        [HttpPost("AddRider")]
        public IActionResult AddRider(RiderDTO riderDTO)
        {
            var rider = _riderRepository.Add(_mapper.Map<Rider>(riderDTO));
            if (rider != null)
                return Ok(rider);
            else
                throw new BadHttpRequestException("Bad Request");
        }


        // PUT: api/Products/id
        [Authorize(Roles = "Admin")]
        [HttpPut("UpdateRiders")]
        public IActionResult UpdateRider(Rider riderChanges)
        {
            var rider = _riderRepository.Update(riderChanges);
            if(rider != null)
                return Ok(riderChanges);
            else
                throw new BadHttpRequestException("Bad Request");
        }

        // DELETE: api/Products/id
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteRider(int id)
        {
            var rider = _riderRepository.GetRider(id);
            if(rider != null)
            {
                _riderRepository.Delete(id);
                return Ok("Deleted Rider");

            }
            throw new NotFoundException("Not found Rider with this Id");
        }
    }
    
}
