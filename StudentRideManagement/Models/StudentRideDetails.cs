using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRideManagement.Models
{
    public class StudentRideDetails
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public Guid AssignedUserId { get; set; }
        public List<RideList> Rides { get; set; }
    }

    public class RideList
    {
        public int RideId { get; set; }
    }
}
