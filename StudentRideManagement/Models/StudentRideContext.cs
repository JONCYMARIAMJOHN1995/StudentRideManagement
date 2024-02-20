using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRideManagement.Models
{
    public class StudentRideContext : IdentityDbContext<ApplicationUser>
    {
        public StudentRideContext(DbContextOptions<StudentRideContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Rider> Rider { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<StudentRide> StudentRide { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }

    }
}
