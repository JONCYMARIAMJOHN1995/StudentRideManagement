using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRideManagement.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            //Seed Role
            List<IdentityRole> roles = new List<IdentityRole>()
            {
                new IdentityRole { 
                    Id = "904867f7-215d-4ebe-bd5b-77738bb6b73e", 
                    Name = "Admin", 
                    NormalizedName = "ADMIN" 
                }
            };
            modelBuilder.Entity<IdentityRole>().HasData(roles);


            //Seed User
            var hasher = new PasswordHasher<IdentityUser>();
            var adminUserPassword = "Admin@123";
            var users = new ApplicationUser
            {
                Id = "66350743-bfba-45b6-9502-9307f954370d",
                UserName = "admin@gmail.com",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                EmailConfirmed = false,
                CreatedDate = DateTime.Now,
                FirstName = "admin",
                LastName = "admin",
                RoleId = new Guid("904867f7-215d-4ebe-bd5b-77738bb6b73e"),
                PasswordHash = hasher.HashPassword(null, adminUserPassword)
            };
            modelBuilder.Entity<ApplicationUser>().HasData(users);


            //Seed UserRole
            List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>();
            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = "66350743-bfba-45b6-9502-9307f954370d",
                RoleId = "904867f7-215d-4ebe-bd5b-77738bb6b73e"
            });
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRoles);

            //Seed Tables
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = 1,
                    Code = "STUDENT_487c78358a734393a70c277db0acdd4b",
                    Description = "Henry 10A",
                    AssignedUserId = new Guid("66350743-bfba-45b6-9502-9307f954370d"),
                    IsActive = true,
                    ValidFrom = DateTime.Now,
                    ValidTo = DateTime.ParseExact("12/31/2049 09:44:55 PM", "MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture)
                    //ValidTo = Convert.ToDateTime("12/31/2049 9:44:55 PM")
                }
           );

            modelBuilder.Entity<Rider>().HasData(
                new Rider
                {
                    Id = 1,
                    Description = "Bus1"
                },
                new Rider
                {
                    Id = 2,
                    Description = "Bus2"
                }
           );

            modelBuilder.Entity<StudentRide>().HasData(
                new StudentRide
                {
                    Id = 1,
                    StudentId = 1,
                    RideId = 1
                },
                new StudentRide
                {
                    Id = 2,
                    StudentId = 1,
                    RideId = 2
                }
           );
        }

    }
}
