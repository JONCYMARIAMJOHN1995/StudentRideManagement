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
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public StudentController(IStudentRepository studentRepository, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
            _userManager = userManager;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("AddStudent")]
        public IActionResult AddStudent(StudentDTO studentDTO)
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            var user = _userManager.Users.FirstOrDefault(x => x.UserName == userEmail);
            var userId = user?.Id;
            Guid assignedUserId = new Guid(userId);

            var student = _studentRepository.Add(_mapper.Map<Student>(studentDTO), assignedUserId);
            if (student != null)
                return Ok(student);
            throw new BadHttpRequestException("Bad Request");
                
        }


        [HttpGet("GetAllStudents")]
        public IActionResult GetAllStudents()
        {

            var students = _studentRepository.GetAllStudents();
            if (students != null)
                return Ok(students);
            else
                throw new Exception("Something went wrong");


        }


        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            var student = _studentRepository.GetStudent(id);
            if (student != null)
                return Ok(student);
            else
                throw new NotFoundException("Not found Student with this Id");
        }


        [Authorize(Roles = "Admin")]
        [HttpPut("UpdateStudent")]
        public IActionResult UpdateStudent(StudentUpdateDTO studentChanges)
        {
            var student = _studentRepository.Update(_mapper.Map<Student>(studentChanges));
            if (student != null)
                return Ok(student);
            else
                throw new BadHttpRequestException("Bad Request");
        }


        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = _studentRepository.GetStudent(id);
            if (student != null)
            {
                _studentRepository.Delete(id);
                return Ok("Deleted student");

            }
            throw new NotFoundException("Not found Student with this Id");
        }

        
        [HttpGet("GetStudentRideDetails")]
        public IActionResult GetStudentRideDetails(int studentId)
        {
            var student = _studentRepository.GetStudent(studentId);
            if (student != null)
            {
                var result = _studentRepository.GetStudentRide(student);
                return Ok(result);
            }
            else
                throw new NotFoundException("Not found !!");
        }
    }
}
