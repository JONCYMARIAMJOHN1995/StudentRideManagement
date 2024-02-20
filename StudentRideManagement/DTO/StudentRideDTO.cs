using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRideManagement.DTO
{
    public class StudentRideDTO
    {
        [Required]
        public int StudentId { get; set; }
        [Required]
        public int RideId { get; set; }
    }
}
