using StudentRideManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRideManagement.Repositories
{
    public interface IStudentRepository
    {
        Student Add(Student student, Guid assignedUserId);
        IEnumerable<Student> GetAllStudents();
        Student GetStudent(int id);
        Student Update(Student studentChanges);
        Student Delete(int id);
        StudentRideDetails GetStudentRide(Student student);
    }
}
