using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentRideManagement.CustomMiddlewares;
using StudentRideManagement.DTO;
using StudentRideManagement.Models;
using StudentRideManagement.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRideManagement.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentRideController : ControllerBase
    {
        private readonly IStudentRideRepository _studentRideRepository;
        private readonly IMapper _mapper;
        private readonly IStudentRepository _studentRepository;
        private readonly IRiderRepository _riderRepository;

        public StudentRideController(IStudentRideRepository studentRideRepository, IMapper mapper,
            IStudentRepository studentRepository, IRiderRepository riderRepository)
        {
            _studentRideRepository = studentRideRepository;
            _mapper = mapper;
            _studentRepository = studentRepository;
            _riderRepository = riderRepository;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("AddStudentRide")]
        public IActionResult AddStudent(StudentRideDTO studentRideDTO)
        {
            Student student = _studentRepository.GetStudent(studentRideDTO.StudentId);
            Rider rider = _riderRepository.GetRider(studentRideDTO.RideId);
            if(student == null || rider == null)
                throw new BadHttpRequestException("Student or Rider not exists");

            IEnumerable<StudentRide> studentRides = _studentRideRepository.GetAllStudentRides();
            foreach (StudentRide s in studentRides) 
            {
                if (s.StudentId == studentRideDTO.StudentId && s.RideId == studentRideDTO.RideId)
                    throw new BadHttpRequestException("This entry already exists");
            }

            var studentRide = _studentRideRepository.Add(_mapper.Map<StudentRide>(studentRideDTO));
            if (studentRide != null)
                return Ok(studentRide);
            throw new BadHttpRequestException("Bad Request");

        }

        [HttpGet("GetAllStudentRides")]
        public IActionResult GetAllStudentRides()
        {

            var studentRides = _studentRideRepository.GetAllStudentRides();
            if (studentRides != null)
                return Ok(studentRides);
            else
                throw new Exception("Something went wrong");
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentRideById(int id)
        {
            var studentRide = _studentRideRepository.GetStudentRide(id);
            if (studentRide != null)
                return Ok(studentRide);
            else
                throw new NotFoundException("Not found StudentRide with this Id");
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("UpdateStudentRide")]
        public IActionResult UpdateStudentRide(StudentRide studentRideChanges)
        {
            Student student = _studentRepository.GetStudent(studentRideChanges.StudentId);
            Rider rider = _riderRepository.GetRider(studentRideChanges.RideId);
            if (student == null || rider == null)
                throw new BadHttpRequestException("Student or Rider not exists");

            IEnumerable<StudentRide> studentRides = _studentRideRepository.GetAllStudentRides();
            foreach (StudentRide s in studentRides)
            {
                if (s.StudentId == studentRideChanges.StudentId && s.RideId == studentRideChanges.RideId)
                    throw new BadHttpRequestException("Can't update because this entry already exists");
            }

            var studentRide = _studentRideRepository.Update(studentRideChanges);
            if (studentRide != null)
                return Ok(studentRide);
            else
                throw new BadHttpRequestException("Bad Request");
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteStudentRide(int id)
        {
            var studentRide = _studentRideRepository.GetStudentRide(id);
            if (studentRide != null)
            {
                _studentRideRepository.Delete(id);
                return Ok("Deleted StudentRide");

            }
            throw new NotFoundException("Not found StudentRide with this Id");
        }

    }
}
