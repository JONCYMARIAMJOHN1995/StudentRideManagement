using StudentRideManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRideManagement.Repositories
{
    public class RiderRepository : IRiderRepository
    {

        private readonly StudentRideContext context;

        public RiderRepository(StudentRideContext context)
        {
            this.context = context;
        }

        public Rider Add(Rider rider)
        {
            context.Rider.Add(rider);
            context.SaveChanges();
            return rider;
        }

        public Rider Delete(int id)
        {
            Rider rider = context.Rider.Find(id);
            if (rider != null)
            {
                context.Rider.Remove(rider);
                context.SaveChanges();
            }

            IEnumerable<StudentRide> studentRides = context.StudentRide.Where(s => s.RideId == rider.Id);
            if (studentRides.Count() > 0)
            {
                foreach (StudentRide studentRide in studentRides)
                {
                    context.StudentRide.Remove(studentRide);
                }
                context.SaveChanges();
            }

            return rider;
        }

        public IEnumerable<Rider> GetAllRiders()
        {
            return context.Rider;
        }

        public Rider GetRider(int id)
        {
            Rider rider = context.Rider.FirstOrDefault(r => r.Id == id);
            return rider;
        }

        public Rider Update(Rider riderChanges)
        {
            var rider = context.Rider.Attach(riderChanges);
            rider.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return riderChanges;
        }
    }
}
