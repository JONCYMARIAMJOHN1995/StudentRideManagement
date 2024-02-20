using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentRideManagement.CustomMiddlewares;
using StudentRideManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace StudentRideManagement.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentRideContext context;
        private readonly UserManager<ApplicationUser> _userManager;

        public StudentRepository(StudentRideContext context, UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            _userManager = userManager;
        }

        public Student Add(Student student, Guid assignedUserId)
        {

            var uniqueCode = Guid.NewGuid().ToString("N");
            student.Code = "STUDENT_" + uniqueCode;


            student.AssignedUserId = assignedUserId;
            student.ValidFrom = DateTime.Now;
            student.ValidTo = Convert.ToDateTime("2049-12-31T17:25:30.240Z");


            context.Student.Add(student);
            context.SaveChanges();
            return student;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return context.Student;
        }

        public Student GetStudent(int id)
        {
            Student student = context.Student.FirstOrDefault(s => s.Id == id);
            return student;
        }

        public Student Update(Student studentChanges)
        {
            Student student = context.Student.FirstOrDefault(s => s.Id == studentChanges.Id);
            if (student != null)
            {
                student.Description = studentChanges.Description;
                student.IsActive = studentChanges.IsActive;
                var studentUpdated = context.Student.Attach(student);
                studentUpdated.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
                return student;
            }
            throw new BadRequestException("Something went wrong");
        }

        public Student Delete(int id)
        {
            Student student = context.Student.Find(id);
            
            if (student != null)
            {
                context.Student.Remove(student);
                context.SaveChanges();
            }

            IEnumerable<StudentRide> studentRides = context.StudentRide.Where(s => s.StudentId == student.Id);
            if(studentRides.Count() > 0)
            {
                foreach (StudentRide studentRide in studentRides)
                {
                    context.StudentRide.Remove(studentRide);
                }
                context.SaveChanges();
            }
            return student;
        }

        public StudentRideDetails GetStudentRide(Student student)
        {
            
            StudentRideDetails studentRideDetails = new StudentRideDetails()
            {
                Id = student.Id,
                Code = student.Code,
                AssignedUserId = student.AssignedUserId,
                Rides = new List<RideList>()
            };

            IEnumerable<StudentRide> studentRides = context.StudentRide.Where(s => s.StudentId == student.Id);
            RideList rides = new RideList();
            if (studentRides.Count() > 0)
            {
                foreach (StudentRide studentRide in studentRides)
                {
                    RideList rideList = new RideList();
                    rideList.RideId = studentRide.RideId;
                    studentRideDetails.Rides.Add(rideList);
                }
            }
            return studentRideDetails;
        }
    }
}
