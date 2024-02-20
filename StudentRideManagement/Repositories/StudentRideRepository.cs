using StudentRideManagement.CustomMiddlewares;
using StudentRideManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRideManagement.Repositories
{
    public class StudentRideRepository : IStudentRideRepository
    {
        private readonly StudentRideContext context;

        public StudentRideRepository(StudentRideContext context)
        {
            this.context = context;
        }

        public StudentRide Add(StudentRide studentRide)
        {
            context.StudentRide.Add(studentRide);
            context.SaveChanges();
            return studentRide;
        }

        public IEnumerable<StudentRide> GetAllStudentRides()
        {
            return context.StudentRide;
        }

        public StudentRide GetStudentRide(int id)
        {
            StudentRide studentRide = context.StudentRide.FirstOrDefault(s => s.Id == id);
            return studentRide;
        }

        public StudentRide Update(StudentRide studentRideChanges)
        {
            StudentRide studentRide = context.StudentRide.Find(studentRideChanges.Id);
            if (studentRide != null)
            {
                var studentRideResult = context.StudentRide.Attach(studentRideChanges);
                studentRideResult.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
                return studentRideChanges;
            }
            throw new BadRequestException("Something went wrong");
        }

        public StudentRide Delete(int id)
        {
            StudentRide studentRide = context.StudentRide.Find(id);
            if (studentRide != null)
            {
                context.StudentRide.Remove(studentRide);
                context.SaveChanges();
            }
            return studentRide;
        }

    }
}
