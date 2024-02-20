using StudentRideManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRideManagement.Repositories
{
    public interface IStudentRideRepository
    {
        StudentRide Add(StudentRide studentRide);
        IEnumerable<StudentRide> GetAllStudentRides();
        StudentRide GetStudentRide(int id);
        StudentRide Update(StudentRide studentRideChanges);
        StudentRide Delete(int id);
    }
}
